<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using MVC_Final.Models;
using MVC_Final.Services;
using MVC_Final.ViewModels;
using NuGet.Protocol.Core.Types;

namespace MVC_Final.Controllers

{
    public class DoctorAdminController : Controller
	{
		 IDoctorAdmin doctorAdmin;
        public DoctorAdminController(IDoctorAdmin _doctorAdmin)
        {
            doctorAdmin = _doctorAdmin;
        }
        public IActionResult GetPatientByName(string name, int id)
        {
            var doctor = doctorAdmin.GetDoctorWithFilteredPatients(name, id);

			var viewModel = new DoctorAdminViewModel
			{
				Doctor = doctor,
				Patients = doctor?.Patients 
            };

            return View("Patients", viewModel);
        }
        public IActionResult GetDoctor(int id=1)
        {
            var doctor = doctorAdmin.GetDoctorById(id);

            if (doctor == null)
            {
                return NotFound("Doctor not found.");
            }

            var viewModel = new DoctorAdminViewModel
            {
                Doctor = doctor,
                Patients = doctor.Patients
            };
            return View("Patients", viewModel);
        }


        public IActionResult Counts(int id)
        {
            // Get the necessary data
            var doctor = doctorAdmin.GetDoctorById(id);
            var patientsCount = doctorAdmin.GetPatientsCount(id);
            var appointmentsCount = doctorAdmin.GetApointsCount(id);
            var totalMoney = doctorAdmin.GetApointsTotalMoney(id);

            // Create the ViewModel
            var viewModel = new DoctorAdminViewModel
            {
                Doctor = doctor,
                PatientsCount = patientsCount,
                AppointmentsCount = appointmentsCount,
                TotalMoney = (decimal)totalMoney
            };

            // Pass the ViewModel to the view
            return View("Patients", viewModel);
        }

        public IActionResult Schedule()
        {
            return View();
        }


        [HttpPost]
     public IActionResult Schedule(WorkingTime schedule,int doctorId)
		{
			if (ModelState.IsValid)
			{
				doctorAdmin.AddSchedule(schedule);
				doctorAdmin.Save();
				return RedirectToAction("Patients");
			}
			return View();
		}
		public IActionResult GetSchedule(int doctorId)
		{
			var scheduleDisplay=doctorAdmin.GetSchedule(doctorId);
			return View("Index", scheduleDisplay);
		}
 }
}
=======
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using MVC_Final.Models;
<<<<<<< HEAD
using MVC_Final.Services;
using MVC_Final.ViewModels;
=======
using MVC_Final.Repositories;
>>>>>>> d576ac289627ee7cbeba60cf9920020457739937
using NuGet.Protocol.Core.Types;

namespace MVC_Final.Controllers

{
<<<<<<< HEAD
    public class DoctorAdminController : Controller
	{
		 IDoctorAdmin doctorAdmin;
        public DoctorAdminController(IDoctorAdmin _doctorAdmin)
        {
            doctorAdmin = _doctorAdmin;
        }
        public IActionResult GetPatientByName(string name, int id)
        {
            var doctor = doctorAdmin.GetDoctorWithFilteredPatients(name, id);

			var viewModel = new DoctorAdminViewModel
			{
				Doctor = doctor,
				Patients = doctor?.Patients 
            };

            return View("Patients", viewModel);
        }
        public IActionResult GetDoctor(int id=1)
        {
            var doctor = doctorAdmin.GetDoctorById(id);

            if (doctor == null)
            {
                return NotFound("Doctor not found.");
            }

            var viewModel = new DoctorAdminViewModel
            {
                Doctor = doctor,
                Patients = doctor.Patients
            };
            return View("Patients", viewModel);
        }


        public IActionResult Counts(int id)
        {
            // Get the necessary data
            var doctor = doctorAdmin.GetDoctorById(id);
            var patientsCount = doctorAdmin.GetPatientsCount(id);
            var appointmentsCount = doctorAdmin.GetApointsCount(id);
            var totalMoney = doctorAdmin.GetApointsTotalMoney(id);

            // Create the ViewModel
            var viewModel = new DoctorAdminViewModel
            {
                Doctor = doctor,
                PatientsCount = patientsCount,
                AppointmentsCount = appointmentsCount,
                TotalMoney = (decimal)totalMoney
            };

            // Pass the ViewModel to the view
            return View("Patients", viewModel);
        }
=======
	public class DoctorAdminController : Controller
	{
		 IDoctorAdmin doctorAdmin;
		public DoctorAdminController(IDoctorAdmin _doctorAdmin)
		{
			doctorAdmin = _doctorAdmin;
		}
        public IActionResult GetPatientByName(string name,int id)
        {

            var patientName = doctorAdmin.GetPatientByName(name,id);

            return View("Patients",patientName);
        }
        public IActionResult GetDoctor(int id,string name)
		{
			var doctor=doctorAdmin.GetDoctorById(id);
            return View("Patients",doctor);
		}		

	

		public IActionResult Counts(int id)
		{
			var patientsCount = doctorAdmin.GetPatientsCount(id);
			ViewBag.PatientsCount = patientsCount;
            var ApointsCount = doctorAdmin.GetApointsCount(id);
            ViewBag.ApointsCount = ApointsCount;
            var totalMoney = doctorAdmin.GetApointsTotalMoney(id);
            ViewBag.TotalMoney = totalMoney;
            return View("Patients");
		}
>>>>>>> d576ac289627ee7cbeba60cf9920020457739937

        public IActionResult Schedule()
        {
            return View();
        }


        [HttpPost]
<<<<<<< HEAD
     public IActionResult Schedule(WorkingTime schedule,int doctorId)
=======
   public IActionResult Schedule(WorkingTime schedule)
>>>>>>> d576ac289627ee7cbeba60cf9920020457739937
		{
			if (ModelState.IsValid)
			{
				doctorAdmin.AddSchedule(schedule);
				doctorAdmin.Save();
				return RedirectToAction("Patients");
			}
			return View();
		}
		public IActionResult GetSchedule(int doctorId)
		{
			var scheduleDisplay=doctorAdmin.GetSchedule(doctorId);
			return View("Index", scheduleDisplay);
		}
 }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
