using Microsoft.AspNetCore.Mvc;
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
