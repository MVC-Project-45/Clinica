<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
﻿using Microsoft.AspNetCore.Mvc;
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
<<<<<<< HEAD
=======
=======
﻿using Microsoft.AspNetCore.Mvc;
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
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
