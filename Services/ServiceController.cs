using Microsoft.AspNetCore.Mvc;
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
