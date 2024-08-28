<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MVC_Final.Models;
using MVC_Final.Services;
using MVC_Final.ViewModels;

namespace MVC_Final.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IDoctorService _doctorService;
        private readonly IReviewService _reviewService;

        public DoctorController(IAdminService adminService, IDoctorService doctorService, IReviewService reviewService)
        {
            _adminService = adminService;
            _doctorService = doctorService;
            _reviewService = reviewService;

        }
        public ActionResult Index(string searchString, int? id)
        {
            List<Doctor> doctors;
            if (id != null)
                doctors = _doctorService.GetBySpecializationId((int)id);
            else
                doctors = _adminService.GetAllDoctorss();
            if (!searchString.IsNullOrEmpty())
            {
                doctors = doctors.Where(d => d.Name.Contains(searchString)).ToList();
            }
            return View("ShowDoctors", doctors);
        }
        public ActionResult Details(int id)
        {
            Doctor doctor = _adminService.GetDoctorByID(id);
            return View(doctor);
        }

        //for the search in /doctor/SearchByName2 view 
        public ActionResult SearchByName2(string search)
        {
            List<Doctor> doctors;
            if (search == null)
                doctors = _adminService.GetAllDoctorss();
            else
                doctors = _doctorService.GetDoctorsByName(search);
            return View("index", doctors);
        }
        //for search in /admin/SearchByName
        public ActionResult SearchByName(string search)
        {
            List<Doctor> doctors;
            if (search == null)
                doctors = _adminService.GetAllDoctorss();
            else
                doctors = _doctorService.GetDoctorsByName(search);
            List<Specialization> sp = _adminService.GetAllSpecializations();
            ListViewModel listView = new ListViewModel();
            listView.doctors = doctors;
            listView.specializations = sp;
            return View("/Views/Admin/Index.cshtml", listView);
        }

        public ActionResult SearchAutocomplete(string term)
        {
            List<string> searchData = _doctorService.GetDoctorsName(term);
            return Json(searchData);
        }

        public ActionResult Add()
        {
            CreateDoctorsFormViewModel doctorVM = new CreateDoctorsFormViewModel();
            doctorVM.WorkingTime = _doctorService.GetWorkingTime();
            doctorVM.Appointments = _doctorService.GetAppointments();
            doctorVM.Reviews = _doctorService.GetReviews();
            doctorVM.SpecializationsList = _doctorService.GetSpecializationsSelectList();

            //doctorVM.Specializations=_adminService.GetSpecializationByID()
            return View(doctorVM);
        }
        public ActionResult save(CreateDoctorsFormViewModel doctor, IFormFile image)//HttpPostedFileBase
        {
            Doctor newDoctor = new Doctor();

            if (doctor.Name != null && image != null && image.Length > 0)
            {
                newDoctor.Name = doctor.Name;

                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image");
                var filePath = Path.Combine(uploads, image.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                newDoctor.Img = image.FileName;
                newDoctor.Address = doctor.Address;
                newDoctor.Qualifications = doctor.Qualifications;
                newDoctor.Reviews = doctor.Reviews;
                //newDoctor.Specializations= doctor.Specializations;
                newDoctor.Specializations = _adminService.GetSpecializationByID((int)doctor.SpecializationId);
                newDoctor.Experince = doctor.Experince;
                newDoctor.SpecializationId = doctor.SpecializationId;
                newDoctor.PhoneNumber = doctor.PhoneNumber;
                newDoctor.Price = doctor.Price;
                newDoctor.TotalRate = doctor.TotalRate;
                //newDoctor.Specializations= _adminService.GetSpecializationByID(newDoctor.SpecializationId);


                _doctorService.AddDoctor(newDoctor);


                return RedirectToAction("Index");
            }

            doctor.WorkingTime = _doctorService.GetWorkingTime();
            doctor.Appointments = _doctorService.GetAppointments();
            doctor.Reviews = _doctorService.GetReviews();

            return View("Add", doctor);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            var doctor = _adminService.GetDoctorByID(id);
            if (doctor is null)
                return NotFound();

            EditDoctorViewModel viewModel = new()
            {
                ID = id,
                Name = doctor.Name,
                Img = doctor.Img,
                CurrentCover = doctor.Img,
                Address = doctor.Address,
                Experince = doctor.Experince,
                Qualifications = doctor.Qualifications,
                PhoneNumber = doctor.PhoneNumber,
                Price = doctor.Price,
                TotalRate = doctor.TotalRate,
                specializations = _adminService.GetAllSpecializations(),
                WorkingTime = _doctorService.GetWorkingTime(),
                SpecializationId = doctor.SpecializationId,
                SpecializationsList = _doctorService.GetSpecializationsSelectList()


            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EditDoctorViewModel model, IFormFile image)
        {
            var doc = await _doctorService.Edit(model, image);

            if (doc is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));


        }
        public IActionResult profile(int id)
        {

            Doctor doctor = _doctorService.GetById(id);

            return View("Profile", doctor);
        }
        public IActionResult ShowComments(int DoctorId)
        {
            List<Review> reviews = _reviewService.GetByDoctor(1);

            return PartialView("_Reviews", reviews);
        }
        [HttpPost]
        public IActionResult AddComment(Review rev)
        {

            Review review = new Review();
            review.Comment = rev.Comment;
            review.DoctorId = rev.DoctorId;
            review.PateintId = 1;
            review.Date = DateTime.Now;
            review.Rate = rev.Rate;

            _doctorService.UpdateTotalRate((int)rev.DoctorId, rev.Rate);

            _reviewService.Add(review);
            _reviewService.Save();

            return PartialView("_Review", review);
        }
    }
}
<<<<<<< HEAD
=======
=======
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MVC_Final.Models;
using MVC_Final.Services;
using MVC_Final.ViewModels;

namespace MVC_Final.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IDoctorService _doctorService;
        private readonly IReviewService _reviewService;

        public DoctorController(IAdminService adminService, IDoctorService doctorService, IReviewService reviewService)
        {
            _adminService = adminService;
            _doctorService = doctorService;
            _reviewService = reviewService;

        }
        public ActionResult Index(string searchString, int? id)
        {
            List<Doctor> doctors;
            if (id != null)
                doctors = _doctorService.GetBySpecializationId((int)id);
            else
                doctors = _adminService.GetAllDoctorss();
            if (!searchString.IsNullOrEmpty())
            {
                doctors = doctors.Where(d => d.Name.Contains(searchString)).ToList();
            }
            return View("ShowDoctors", doctors);
        }
        public ActionResult Details(int id)
        {
            Doctor doctor = _adminService.GetDoctorByID(id);
            return View(doctor);
        }

        //for the search in /doctor/SearchByName2 view 
        public ActionResult SearchByName2(string search)
        {
            List<Doctor> doctors;
            if (search == null)
                doctors = _adminService.GetAllDoctorss();
            else
                doctors = _doctorService.GetDoctorsByName(search);
            return View("index", doctors);
        }
        //for search in /admin/SearchByName
        public ActionResult SearchByName(string search)
        {
            List<Doctor> doctors;
            if (search == null)
                doctors = _adminService.GetAllDoctorss();
            else
                doctors = _doctorService.GetDoctorsByName(search);
            List<Specialization> sp = _adminService.GetAllSpecializations();
            ListViewModel listView = new ListViewModel();
            listView.doctors = doctors;
            listView.specializations = sp;
            return View("/Views/Admin/Index.cshtml", listView);
        }

        public ActionResult SearchAutocomplete(string term)
        {
            List<string> searchData = _doctorService.GetDoctorsName(term);
            return Json(searchData);
        }

        public ActionResult Add()
        {
            CreateDoctorsFormViewModel doctorVM = new CreateDoctorsFormViewModel();
            doctorVM.WorkingTime = _doctorService.GetWorkingTime();
            doctorVM.Appointments = _doctorService.GetAppointments();
            doctorVM.Reviews = _doctorService.GetReviews();
            doctorVM.SpecializationsList = _doctorService.GetSpecializationsSelectList();

            //doctorVM.Specializations=_adminService.GetSpecializationByID()
            return View(doctorVM);
        }
        public ActionResult save(CreateDoctorsFormViewModel doctor, IFormFile image)//HttpPostedFileBase
        {
            Doctor newDoctor = new Doctor();

            if (doctor.Name != null && image != null && image.Length > 0)
            {
                newDoctor.Name = doctor.Name;

                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image");
                var filePath = Path.Combine(uploads, image.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                newDoctor.Img = image.FileName;
                newDoctor.Address = doctor.Address;
                newDoctor.Qualifications = doctor.Qualifications;
                newDoctor.Reviews = doctor.Reviews;
                //newDoctor.Specializations= doctor.Specializations;
                newDoctor.Specializations = _adminService.GetSpecializationByID((int)doctor.SpecializationId);
                newDoctor.Experince = doctor.Experince;
                newDoctor.SpecializationId = doctor.SpecializationId;
                newDoctor.PhoneNumber = doctor.PhoneNumber;
                newDoctor.Price = doctor.Price;
                newDoctor.TotalRate = doctor.TotalRate;
                //newDoctor.Specializations= _adminService.GetSpecializationByID(newDoctor.SpecializationId);


                _doctorService.AddDoctor(newDoctor);


                return RedirectToAction("Index");
            }

            doctor.WorkingTime = _doctorService.GetWorkingTime();
            doctor.Appointments = _doctorService.GetAppointments();
            doctor.Reviews = _doctorService.GetReviews();

            return View("Add", doctor);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            var doctor = _adminService.GetDoctorByID(id);
            if (doctor is null)
                return NotFound();

            EditDoctorViewModel viewModel = new()
            {
                ID = id,
                Name = doctor.Name,
                Img = doctor.Img,
                CurrentCover = doctor.Img,
                Address = doctor.Address,
                Experince = doctor.Experince,
                Qualifications = doctor.Qualifications,
                PhoneNumber = doctor.PhoneNumber,
                Price = doctor.Price,
                TotalRate = doctor.TotalRate,
                specializations = _adminService.GetAllSpecializations(),
                WorkingTime = _doctorService.GetWorkingTime(),
                SpecializationId = doctor.SpecializationId,
                SpecializationsList = _doctorService.GetSpecializationsSelectList()


            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EditDoctorViewModel model, IFormFile image)
        {
            var doc = await _doctorService.Edit(model, image);

            if (doc is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));


        }
        public IActionResult profile(int id)
        {

            Doctor doctor = _doctorService.GetById(id);

            return View("Profile", doctor);
        }
        public IActionResult ShowComments(int DoctorId)
        {
            List<Review> reviews = _reviewService.GetByDoctor(1);

            return PartialView("_Reviews", reviews);
        }
        [HttpPost]
        public IActionResult AddComment(Review rev)
        {

            Review review = new Review();
            review.Comment = rev.Comment;
            review.DoctorId = rev.DoctorId;
            review.PateintId = 1;
            review.Date = DateTime.Now;
            review.Rate = rev.Rate;

            _doctorService.UpdateTotalRate((int)rev.DoctorId, rev.Rate);

            _reviewService.Add(review);
            _reviewService.Save();

            return PartialView("_Review", review);
        }
    }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
