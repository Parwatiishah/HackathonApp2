using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;

namespace CollegeSoftApp.Controllers
{
    public class ClassesController : Controller
    {
        public async Task <IActionResult> Index()
        {
            List<Class>? classes = await DataAccess.GetClassList();
            return View(classes);
        }
        public async Task<IActionResult> Create(){
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Class c)
        {
            await DataAccess.CreateClass(c);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            var classes = await DataAccess.GetClassDetails(id);
            return PartialView();
        }

    }
}
