using CollegeSoftApp.DataAccessLayer;
using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.Controllers
{
    public class VacanciesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<VacancyView>? vs = await DataAccess.GetVacancy();
            return View(vs);
        }
        [HttpGet]
        public async Task<IActionResult> create()
        {
            /*List<User>? us = await DataAccess.GetUserLists();

            ViewBag.uList = new SelectList(us, nameof(User.UserId), nameof(uList.UserName));*/
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> create(VacancyEdit v)
        {
            await DataAccess.CreateVacancy(v);
            return RedirectToAction("Index");
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            VacancyView vs = new VacancyView();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(vs), Encoding.UTF8);
                using (var response = await httpClient.DeleteAsync("https://localhost:7027/api/Vacancies"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                }

            }
            return View();
        }

    }
    }

