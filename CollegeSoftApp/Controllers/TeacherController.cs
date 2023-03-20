using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeSoftApp.Controllers
{
    public class TeacherController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<TeacherView>? teachers = await DataAccess.GetTeacher();
            return View(teachers);
        }
        [HttpGet]
        public async Task<IActionResult> create()
        {
            List<RoleList>? roles = await DataAccess.GetRoleLists();
            
            ViewBag.RoleList = new SelectList(roles, nameof(RoleList.RoleId), nameof(RoleList.RoleName));
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> create(TeacherEdit teacher)
        {
            await DataAccess.CreateTecaher(teacher);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            //Authorise
            if (User.IsInRole("Teacher"))
            {
                TeacherView? teachers = await DataAccess.GetTeacherDetails(Convert.ToInt32(User.Identity.Name));
                return PartialView();
            }
            else
            {
                var teachers = await DataAccess.GetTeacherDetails(id);
                return PartialView();
            }
            
        }
       
    }
}
