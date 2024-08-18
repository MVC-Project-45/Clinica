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

			return View("_DoctorDashboard", Patients);
		}

		public IActionResult SearchByName(string name)
		{
			var patientName=doctorAdmin.GetPatientByName(name);
			return View("_DoctorDashboard", patientName);
		}

		public IActionResult PatientsCount()
		{
			var patientsCount = doctorAdmin.GetPatientsCount();
			ViewBag.PatientsCount = patientsCount;
			return View("_DoctorDashboard");
		}
		public ActionResult GetTotalMoney()
		{
			var totalMoney= doctorAdmin.GetApointsTotalMoney();
			ViewBag.TotalMoney = totalMoney;
			return View("_DoctorDashboard");
		}
		public IActionResult ApointsCount()
		{
			var ApointsCount = doctorAdmin.GetApointsCount();
			ViewBag.ApointsCount = ApointsCount;
			return View("PatientsCount");
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
				return RedirectToAction("PatientsCount");
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
