<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Final.ViewModel;

namespace MVC_Final.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult AddRole()

        {
     
            return View("AddRole");
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole(RoleViewModel roleViewModel)
        {
            if(ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleViewModel.RoleName;
            IdentityResult result =  await  roleManager.CreateAsync(role);
                if(result.Succeeded == true)
                {
                    ViewBag.sucess = true;
                    return View("AddRole");

                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                //Save DB
            }
            return View("AddRole", roleViewModel);
        }
    }
=======
﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Final.ViewModel;

namespace MVC_Final.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult AddRole()

        {
     
            return View("AddRole");
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole(RoleViewModel roleViewModel)
        {
            if(ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleViewModel.RoleName;
            IdentityResult result =  await  roleManager.CreateAsync(role);
                if(result.Succeeded == true)
                {
                    ViewBag.sucess = true;
                    return View("AddRole");

                }
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                //Save DB
            }
            return View("AddRole", roleViewModel);
        }
    }
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
}