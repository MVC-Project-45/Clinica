using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Final.Models;

namespace MVC_Final.Controllers
{
    public class PatientController : Controller
    {
       
        private readonly Context _context;

        public PatientController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var patients = _context.Patients.ToList(); // Assuming you have a DbContext named "_context"
            return View(patients);
        }

        //public PatientController(Context context)
        //{
        //    _context = context;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    var patients = await _context.Patients.ToListAsync();
        //    return View(patients);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Name, Age, Gender, PhoneNumber, Address")] Patient patient)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Patients.Add(patient);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(patient);
        //}
    }
}
