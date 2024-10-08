<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
﻿using Microsoft.AspNetCore.Mvc;
using MVC_Final.Models;
using MVC_Final.Services;

namespace MVC_Final.Controllers
{
    public class SpecializationsController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IDoctorService _doctorService;

        public SpecializationsController(IAdminService adminService, IDoctorService doctorService)
        {
            _adminService = adminService;
            _doctorService = doctorService;

        }
        public ActionResult Index()
        {
            List<Specialization> specializations = _adminService.GetAllSpecializations();
            return View(specializations);
        }
        public ActionResult Details(int id)
        {            
            return RedirectToAction("Index","Doctor",id);
        }
        public ActionResult SearchByName(string search)
        {
            List<Specialization> specializations;
            if (search == null)
                specializations = _adminService.GetAllSpecializations();
            else
              {
                List<Doctor> doctors;
                specializations = _adminService.GetSpecializationsByName(search); }
            return View("index", specializations);
        }
    }
}
<<<<<<< HEAD
=======
=======
﻿using Microsoft.AspNetCore.Mvc;
using MVC_Final.Models;
using MVC_Final.Services;

namespace MVC_Final.Controllers
{
    public class SpecializationsController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IDoctorService _doctorService;

        public SpecializationsController(IAdminService adminService, IDoctorService doctorService)
        {
            _adminService = adminService;
            _doctorService = doctorService;

        }
        public ActionResult Index()
        {
            List<Specialization> specializations = _adminService.GetAllSpecializations();
            return View(specializations);
        }
        public ActionResult Details(int id)
        {            
            return RedirectToAction("Index","Doctor",id);
        }
        public ActionResult SearchByName(string search)
        {
            List<Specialization> specializations;
            if (search == null)
                specializations = _adminService.GetAllSpecializations();
            else
              {
                List<Doctor> doctors;
                specializations = _adminService.GetSpecializationsByName(search); }
            return View("index", specializations);
        }
    }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
>>>>>>> 84f9ff5d8f56ef279a027ce172551f645af7c764
