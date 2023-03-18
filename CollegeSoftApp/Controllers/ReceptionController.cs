using Microsoft.AspNetCore.Mvc;

namespace CollegeSoftApp.Controllers
{
    public class ReceptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
