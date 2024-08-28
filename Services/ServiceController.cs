<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVC_Final.Services
{
    public class ServiceController : Controller
    {
        public IActionResult TestAuth()
        {
            if(User.Identity.IsAuthenticated ==true)
            {
                Claim IDClaim  = User.Claims.FirstOrDefault(c =>c.Type == ClaimTypes.NameIdentifier);
                string ID = IDClaim.Value;

              string name =  User.Identity.Name;
                return Content($"Welcome {name} \t ID: {ID}");
            }
            return Content("welcome ");
        }

    }
}
=======
﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVC_Final.Services
{
    public class ServiceController : Controller
    {
        public IActionResult TestAuth()
        {
            if(User.Identity.IsAuthenticated ==true)
            {
                Claim IDClaim  = User.Claims.FirstOrDefault(c =>c.Type == ClaimTypes.NameIdentifier);
                string ID = IDClaim.Value;

              string name =  User.Identity.Name;
                return Content($"Welcome {name} \t ID: {ID}");
            }
            return Content("welcome ");
        }

    }
}
>>>>>>> b905b14e014d082ee4d3e4a1db7d5c994c74a9c2
