using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class DataAccess
    {
        public static async Task<List<User>?> GetUserLists()
        {

            List<User>? u = new List<User>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/Users"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    u = JsonConvert.DeserializeObject<List<User>>(apiresponse);
                }
                return u;
            }
            catch
            {
                return u;
            }

        }
        //id
        public static async Task<List<User?>> GetUserDetails(int id)
        {
            List<User>? u = new List<User>();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/Users/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                u = JsonConvert.DeserializeObject<List<User>>(apiresponse);
            }
            return u;
        }
        public static async Task<User?> CreateUserList(User us)
        {
            User? u = new User();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(us), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/Users", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
            }
            return u;
        }
    }
}
