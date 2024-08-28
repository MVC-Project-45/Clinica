using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Final.Models;
using MVC_Final.ViewModels;

namespace MVC_Final.Services
{
    public interface IDoctorService
    {
        IEnumerable<SelectListItem> GetSelectList();
        public List<Doctor> GetDoctorsByName(string searchName);
        public List<string> GetDoctorsName(string searchName);
        public List<WorkingTime> GetWorkingTime();
        public List<Appointment> GetAppointments();
        public List<Review> GetReviews();
        public ICollection<SelectListItem> GetSpecializationsSelectList();
        public void AddDoctor(Doctor newDoctor);
        Task<Doctor?> Edit(EditDoctorViewModel model, IFormFile image);
        public Doctor GetById(int id);
        public void UpdateTotalRate(int id, float ratevalue);
        public List<Doctor> GetBySpecializationId(int id);




    }
}
