using Microsoft.AspNetCore.Mvc;

namespace MVC_Final.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
