<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Final.Models;
using MVC_Final.ViewModels;

namespace MVC_Final.Services
{
    public interface IAdminService
    {
        
        public  List<Specialization> GetAllSpecializations();
         
        public Specialization GetSpecializationByID(int id);
        public void AddSpecialization(Specialization newSpecialization);
        public void UpdateSpecialization(Specialization updatedSpecialization);
        public void DeleteSpecialization(int id);
        
        public List<Specialization> GetSpecializationsByName(string searchName);
        public  List<string> GetSpecializationsName(string searchName);

        Task<Specialization?> Edit(EditSpecializationViewModel model, IFormFile image);

        // ////////////////////////////////////////
        public List<Doctor> GetAllDoctorss();

        ICollection<SelectListItem> GetSelectList();
        public Doctor GetDoctorByID(int id);
        public void DeleteDoctorFromSpecialization(int id);
        public void DeleteDoctorFromDB(int id);
        // ///////////////////////////////////////
        void Save();
        

    }
}
=======
﻿using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Final.Models;
using MVC_Final.ViewModels;

namespace MVC_Final.Services
{
    public interface IAdminService
    {
        
        public  List<Specialization> GetAllSpecializations();
         
        public Specialization GetSpecializationByID(int id);
        public void AddSpecialization(Specialization newSpecialization);
        public void UpdateSpecialization(Specialization updatedSpecialization);
        public void DeleteSpecialization(int id);
        
        public List<Specialization> GetSpecializationsByName(string searchName);
        public  List<string> GetSpecializationsName(string searchName);

        Task<Specialization?> Edit(EditSpecializationViewModel model, IFormFile image);

        // ////////////////////////////////////////
        public List<Doctor> GetAllDoctorss();

        ICollection<SelectListItem> GetSelectList();
        public Doctor GetDoctorByID(int id);
        public void DeleteDoctorFromSpecialization(int id);
        public void DeleteDoctorFromDB(int id);
        // ///////////////////////////////////////
        void Save();
        

    }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
