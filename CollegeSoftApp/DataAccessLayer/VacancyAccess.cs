using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class DataAccess
    {

        public static async Task<List<VacancyView>?> GetVacancy()
        {

            List<VacancyView>? vs = new List<VacancyView>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/Vacancies"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    vs = JsonConvert.DeserializeObject<List<VacancyView>>(apiresponse);
                }
                return vs;
            }
            catch
            {
                return vs;
            }

        }
        //id
        public static async Task<List<VacancyView?>> GetVacancy(int id)
        {
            List<VacancyView>? vs = new List<VacancyView>();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/Vacancies/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                vs = JsonConvert.DeserializeObject<List<VacancyView>>(apiresponse);
            }
            return vs;
        }
        public static async Task<VacancyEdit?> CreateVacancy(VacancyEdit vacancy)
        {
            VacancyEdit? vacancies = new VacancyEdit();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(vacancy), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/Vacancies", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
            }
            return vacancies;
        }
       
    }
}
