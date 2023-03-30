using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeSoftApp.Controllers
{
    public class ProgramInfoesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<PrograInfoView>? programs = await DataAccess.GetProgramInfo();
            return View(programs);
        }
        [HttpGet]
        public async Task<IActionResult> create()
        {
           /* List<User>? u = await DataAccess.GetUserLists();

            ViewBag.userList = new SelectList(u, nameof(User.UserId), nameof(User.UserName));*/
            return PartialView();
        }

        

        [HttpPost]
        public async Task<IActionResult> create(ProgramInfoEdit program)
        {
            await DataAccess.CreateProgramInfo(program);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            await DataAccess.GetProgramInfoDetails(id);
            return PartialView();
        }
       
    }
}
