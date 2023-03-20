using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class DataAccess
    {
        public static async Task<List<TeacherView>?> GetTeacher()
        {

            List<TeacherView>? teachers = new List<TeacherView>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/Teachers"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    teachers = JsonConvert.DeserializeObject<List<TeacherView>>(apiresponse);
                }
                return teachers;
            }
            catch
            {
                return teachers;
            }

        }
        //id
        public static async Task<TeacherView?> GetTeacherDetails(int id)
        {
            TeacherView? teacher = new TeacherView();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/Teachers/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                teacher = JsonConvert.DeserializeObject<TeacherView>(apiresponse);
            }
            return teacher;
        }
        public static async Task<TeacherEdit?> CreateTecaher(TeacherEdit teacher)
        {
            TeacherEdit? teachers = new TeacherEdit();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(teacher), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/Teachers", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
            }
            return teachers;
        }
    }
}
