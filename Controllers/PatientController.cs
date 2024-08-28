<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
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
=======
﻿using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using MVC_Final.Models;
=======
>>>>>>> d576ac289627ee7cbeba60cf9920020457739937

namespace MVC_Final.Controllers
{
    public class PatientController : Controller
    {
<<<<<<< HEAD
       
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
=======
        public IActionResult Index()
        {
            return View();
        }
>>>>>>> d576ac289627ee7cbeba60cf9920020457739937
    }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
