using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Final.Models;
using MVC_Final.ViewModels;

namespace MVC_Final.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly Context _context;
        public DoctorService(Context context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Doctors
               .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
               .OrderBy(d => d.Text)
               .AsNoTracking()
               .ToList();
        }
        public List<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }
        public List<Doctor> GetDoctorsByName(string searchName)
        {
            return _context.Doctors.Where(i => i.Name.Contains(searchName)).ToList();
        }
        public List<string> GetDoctorsName(string searchName)
        {
            return _context.Doctors.Where(i => i.Name.Contains(searchName)).Select(c => c.Name).ToList();
        }
        public List<WorkingTime> GetWorkingTime()
        {
            return _context.WorkingTime.ToList();
        }
        public List<Appointment> GetAppointments()
        {
            return _context.Appointments.ToList();
        }
        public List<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }
        public ICollection<SelectListItem> GetSpecializationsSelectList()
        {
            return _context.Specializations
                    .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                    .OrderBy(d => d.Text)
                    .AsNoTracking()
                    .ToList();
        }
        public void AddDoctor(Doctor newDoctor)
        {
            _context.Doctors.Add(newDoctor);
            _context.SaveChanges();
        }

        public async Task<Doctor?> Edit(EditDoctorViewModel model, IFormFile image)
        {
            var doctor = _context.Doctors
                .Include(d => d.Specializations)
                .SingleOrDefault(d => d.Id == model.ID);

            if (doctor is null)
                return null;



            doctor.Name = model.Name;
            doctor.Address = model.Address;
            doctor.Experince = model.Experince;
            doctor.Qualifications = model.Qualifications;
            doctor.SpecializationId = model.SpecializationId;
            var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image");
            var filePath = Path.Combine(uploads, image.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            doctor.Img = image.FileName;




            var effectedRows = _context.SaveChanges();
            return doctor;
        }
        public Doctor GetById(int id)
        {
            return _context.Doctors
                .Include(d => d.Appointments)
                .Include(d => d.Specializations)
                .Include(d => d.WorkingTime)
                 .Include(d => d.Reviews)
                .FirstOrDefault(x => x.Id == id);

        }
        public List<Doctor> GetBySpecializationId(int id)
        {
            return _context.Doctors
                .Include(d => d.Appointments)
                .Include(d => d.Specializations)
                .Include(d => d.WorkingTime)
                 .Include(d => d.Reviews)
                 .Where(x => x.Id == id)
                 .ToList();

        }
        public void UpdateTotalRate(int id, float ratevalue)
        {
            Doctor doctor = GetById(id);
            if (doctor.TotalRate == null)
                doctor.TotalRate = 0;
            doctor.TotalRate += ratevalue;
        }

    }
}
