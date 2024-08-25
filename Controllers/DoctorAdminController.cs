using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
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
