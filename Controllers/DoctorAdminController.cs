using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Final.Models;
using MVC_Final.Repositories;
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

		[HttpGet]
		public IActionResult GetPatients()
		{

			var Patients = doctorAdmin.GetAllPatients();

			return View("Patients", Patients);
		}

		public IActionResult SearchByName(string name)
		{
			var patientName=doctorAdmin.GetPatientByName(name);
			return View("Patients", patientName);
		}

		public IActionResult Counts()
		{
			var patientsCount = doctorAdmin.GetPatientsCount();
			ViewBag.PatientsCount = patientsCount;
            var ApointsCount = doctorAdmin.GetApointsCount();
            ViewBag.ApointsCount = ApointsCount;
            var totalMoney = doctorAdmin.GetApointsTotalMoney();
            ViewBag.TotalMoney = totalMoney;
            return View("Patients");
		}

        public IActionResult Schedule()
        {
            return View();
        }


        [HttpPost]
   public IActionResult Schedule(WorkingTime schedule)
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
