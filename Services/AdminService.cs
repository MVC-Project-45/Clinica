using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Final.Models;
using MVC_Final.Settings;
using MVC_Final.ViewModels;

namespace MVC_Final.Services
{
    public class AdminService : IAdminService
    {
        private readonly Context _context;

        public AdminService(Context context)
        {
            _context = context;
        }
        /// //////////FormatException specializations /////////////////
        public List<Specialization> GetAllSpecializations()
        {
            return _context.Specializations.ToList();
        }

        public ICollection<SelectListItem> GetSelectList()
        {
            return _context.Doctors
                    .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                    .OrderBy(d => d.Text)
                    .AsNoTracking()
                    .ToList();
        }
        public Specialization GetSpecializationByID(int id)
        {
            return _context.Specializations
                .Where(i => i.Id == id).Include(i => i.Doctors)
                .FirstOrDefault();
        }
        public void AddSpecialization(Specialization newSpecialization)
        {
            _context.Specializations.Add(newSpecialization);
            _context.SaveChanges();
        }
        public void UpdateSpecialization(Specialization updatedSpecialization)
        {
            var existingSpecialization = GetSpecializationByID(updatedSpecialization.Id);

            if (existingSpecialization != null)
            {
                existingSpecialization.Doctors = updatedSpecialization.Doctors;
                existingSpecialization.Name = updatedSpecialization.Name;
                existingSpecialization.Cover = updatedSpecialization.Cover;

                _context.SaveChanges();
            }
        }

        public void DeleteSpecialization(int id)
        {
            var specializationToDelete = GetSpecializationByID(id);

            if (specializationToDelete != null)
            {
                _context.Specializations.Remove(specializationToDelete);
                _context.SaveChanges();
            }
        }


        public List<Specialization> GetSpecializationsByName(string searchName)
        {
            return _context.Specializations.Where(i => i.Name.Contains(searchName)).ToList();
        }
        public List<string> GetSpecializationsName(string searchName)
        {
            return _context.Specializations.Where(i => i.Name.Contains(searchName)).Select(c => c.Name).ToList();
        }
        public async Task<Specialization?> Edit(EditSpecializationViewModel model, IFormFile image)
        {
            var sp = _context.Specializations
                .Include(s => s.Doctors)
                .SingleOrDefault(s => s.Id == model.ID);

            if (sp is null)
                return null;

            sp.Name = model.Name;
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image");
            var filePath = Path.Combine(uploads, image.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            sp.Cover = image.FileName;

            if (model.SelectedDoctors != null)
            {
                List<int> selectedDoctorsFromList = model.SelectedDoctors;

                List<Doctor> _doctors = GetAllDoctorss();

                foreach (var doctor in _doctors)
                {

                    foreach (var id in selectedDoctorsFromList)
                    {
                        if (doctor.Id == id)
                        {
                            GetDoctorByID(id).SpecializationId = sp.Id;
                            Save();
                            break;
                        }
                    }
                }
            }
            var effectedRows = _context.SaveChanges();
            return sp;
        }
        // ////////////for doctors////////////////
        public List<Doctor> GetAllDoctorss()
        {
            return _context.Doctors.Include(d => d.Appointments)
                .Include(d => d.Specializations)
                .Include(d => d.WorkingTime)
                .Include(d => d.Reviews)
                .Include(d => d.Appointments)
                .ToList();
        }
        public Doctor GetDoctorByID(int id)
        {
            return _context.Doctors.FirstOrDefault(d => d.Id == id);
        }
        public void DeleteDoctorFromSpecialization(int id)
        {
            var doctorToDelete = GetDoctorByID(id);
            if (doctorToDelete != null)
            {
                doctorToDelete.SpecializationId = null;
                _context.SaveChanges();
            }
        }
        public void DeleteDoctorFromDB(int id)
        {
            var doctorToDelete = GetDoctorByID(id);

            if (doctorToDelete != null)
            {
                _context.Doctors.Remove(doctorToDelete);
                _context.SaveChanges();
            }
        }
        // /////////////////////////
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
