using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Final.Models;
using MVC_Final.Services;
using MVC_Final.ViewModels;

namespace MVC_Final.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IDoctorService _doctorService;

        public AdminController(IAdminService adminService, IDoctorService doctorService)
        {
            _adminService = adminService;
            _doctorService = doctorService;

        }
        public ActionResult Index()
        {
            var listVM=new ListViewModel();
            listVM.specializations=_adminService.GetAllSpecializations();
            listVM.doctors=_adminService.GetAllDoctorss();
            return View("Index",listVM);
        }
        public ActionResult Details(int id)
        {
            Specialization specialization = _adminService.GetSpecializationByID(id);
            return View(specialization);
        }

        public ActionResult Add()
        {
            CreateSpecializationFormViewModel specializationDetailsViewModel = new CreateSpecializationFormViewModel();
            specializationDetailsViewModel.Doctors = _adminService.GetSelectList();
            return View(specializationDetailsViewModel);
        }
        
        public ActionResult save(CreateSpecializationFormViewModel specialization, IFormFile image)//HttpPostedFileBase
        {
            Specialization newSpecialization = new Specialization();
            
            if (specialization.Name != null && image != null && image.Length > 0)
            {
                newSpecialization.Name = specialization.Name;
              
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image");
                var filePath = Path.Combine(uploads, image.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                newSpecialization.Cover = image.FileName;
                
                 _adminService.AddSpecialization(newSpecialization);
               
               List<int> selectedDoctorsFromList=specialization.SelectedDoctors;
                if (selectedDoctorsFromList!=null)
                {
                    List<Doctor> _doctors = _adminService.GetAllDoctorss();
                    foreach (var doctor in _doctors)
                    {
                        foreach (var id in selectedDoctorsFromList)
                        {
                            if (doctor.Id == id)
                            {
                                _adminService.GetDoctorByID(id).SpecializationId = newSpecialization.Id;
                                _adminService.Save();
                                break;
                            }
                        }
                    }
                }
                return RedirectToAction("Index");
            }

            specialization.Doctors = _adminService.GetSelectList();

            return View("Add", specialization);
        }
        public ActionResult SearchByName(string search)
        {
            List<Specialization> specializations;
            if (search == null)
                specializations = _adminService.GetAllSpecializations();
            else
                specializations = _adminService.GetSpecializationsByName(search);
            ListViewModel listView = new ListViewModel();
            listView.specializations = specializations;
            listView.doctors=_adminService.GetAllDoctorss();
            
            return View("index", listView);
        }

        public ActionResult SearchAutocomplete(string term)
        {
            List<string> searchData = _adminService.GetSpecializationsName(term);
            return Json(searchData);
        }
        public ActionResult Delete(int id)
        {
            Specialization sp = _adminService.GetSpecializationByID(id);
            return View(sp);
        }
        
        public ActionResult ConfirmDelete(int id)
        {
            _adminService.DeleteSpecialization(id);
            return RedirectToAction("index");
        }
        public ActionResult DeleteDoctor(int id)
        {
            Doctor doc = _adminService.GetDoctorByID(id);
            return View(doc);
        }
        public ActionResult ConfirmDeleteDoctor(int id)
        {
                int spId = _adminService.GetDoctorByID(id).SpecializationId.Value;
                _adminService.DeleteDoctorFromSpecialization(id);
                return RedirectToAction("Update", new { id = spId });
        }
        public ActionResult ConfirmDeleteDoctorFromDB(int id)
        {
            _adminService.DeleteDoctorFromDB(id);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            
            var specialization=_adminService.GetSpecializationByID(id);
            if (specialization is null)
                return NotFound();
            List<int> selectedDoctorsFromList = new List<int>();
            foreach (var doctor in specialization.Doctors)
            {
                selectedDoctorsFromList.Add(doctor.Id);
            }
            EditSpecializationViewModel viewModel = new()
            {
                ID=id,
                Name=specialization.Name,
                Cover=specialization.Cover,
                CurrentCover=specialization.Cover,
                Doctors=_adminService.GetSelectList(),
                SelectedDoctors=selectedDoctorsFromList,
                doctors=_adminService.GetAllDoctorss()
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EditSpecializationViewModel model, IFormFile image)
        {
            var sp = await _adminService.Edit(model,image);

            if (sp is null)
                return BadRequest();
            return RedirectToAction(nameof(Index));
            

        }
       

    }
}
