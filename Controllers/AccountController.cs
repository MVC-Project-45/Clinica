using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_Final.Models;
using MVC_Final.ViewModel;

namespace MVC_Final.Controllers
{
   
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        //register
        [HttpGet]
        public IActionResult Register()
        {
           
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SaveRegister(RegisterUserViewModel userViewModel)
        {
            if(ModelState.IsValid)
            {
                //Mapping
            
                ApplicationUser appUser = new ApplicationUser();
                appUser.UserName = userViewModel.UserName;
              //  appUser.age = userViewModel.age;
              //  appUser.gender = userViewModel.Gender;
                appUser.Email = userViewModel.Email;
               // appUser.Address= userViewModel.Address;
                appUser.PasswordHash = userViewModel.Password;
                //save datebase

                    IdentityResult result =await userManager.CreateAsync(appUser, userViewModel.Password);
                if(result.Succeeded)
                {
                    //asign to role

                     //await  userManager.AddToRoleAsync(appUser, "Admin");

                     await  userManager.AddToRoleAsync(appUser, "docutor");


                    //cookie
                    await signInManager.SignInAsync(appUser,false);

                    return RedirectToAction("Index", "Home");



                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                    
                }




            }
            return View("Register",userViewModel);

        }
        //login
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> SaveLogin(LoginUserViewModel userViewModel)
        {

            if(ModelState.IsValid)
            {
                //check found


                ApplicationUser appUser = await userManager.FindByEmailAsync(userViewModel.Email); //FindByNameAsync(userViewModel.PhoneNumber);
                if(appUser != null)
                {

                    bool found = await userManager.CheckPasswordAsync(appUser, userViewModel.Password);

                    if(found == true)
                    {
                      await  signInManager.SignInAsync(appUser, userViewModel.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }

                }

                ModelState.AddModelError("", "Phone or password Wrong !");

                //create cookie
            }
            return View("Login", userViewModel);

        }
        //signout
        public async Task<IActionResult> SignOut()
        {
           await signInManager.SignOutAsync();
            return View("Login");
        }


        //admin---------------


        //register

        [HttpGet]

        [Authorize]
        public IActionResult RegisterAdmin()
        {

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SaveRegisterAdmin(RegisterUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                //Mapping

                ApplicationUser appUser = new ApplicationUser();
                appUser.UserName = userViewModel.UserName;

                appUser.PasswordHash = userViewModel.Password;
                //save datebase

                IdentityResult result = await userManager.CreateAsync(appUser, userViewModel.Password);
                if (result.Succeeded)
                {
                    //asign to role

                    await userManager.AddToRoleAsync(appUser, "Admin");


                    //cookie
                    await signInManager.SignInAsync(appUser, false);

                    return RedirectToAction("Index", "Home");



                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);

                }




            }
            return View("RegisterAdmin", userViewModel);

        }


        //loginAdmin

        [Authorize]
        public IActionResult LoginAdmin()
        {
            return View("LoginAdmin");
        }
        [HttpPost]
        public async Task<IActionResult> SaveLoginAdmin(LoginUserViewModel userViewModel)
        {

            if (ModelState.IsValid)
            {
                //check found


                ApplicationUser appUser = await userManager.FindByNameAsync(userViewModel.Email);
                if (appUser != null)
                {

                    bool found = await userManager.CheckPasswordAsync(appUser, userViewModel.Password);

                    if (found == true)
                    {
                        await signInManager.SignInAsync(appUser, userViewModel.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }

                }

                ModelState.AddModelError("", "Phone or password Wrong !");

                //create cookie
            }
            return View("Home", userViewModel);

        }




    }
}
