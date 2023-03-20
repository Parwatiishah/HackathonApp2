using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial  class DataAccess
    {
        public static async Task<List<Class>?> GetClassList()
        {
            List<Class>? classes = new List<Class>();
            HttpClient client = new HttpClient();
            using (var response=await client.GetAsync("https://localhost:7027/api/Classes"))
            {
                string apiresponse=await response.Content.ReadAsStringAsync();
                classes=JsonConvert.DeserializeObject<List<Class>>(apiresponse);
            }
            return classes;
        }
        //id
        public static async Task<Class?> GetClassDetails(int id)
        {
            var Classes = new Class();
            HttpClient client = new HttpClient();
            using(var response =await client.GetAsync("https://localhost:7027/api/Classes/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                Classes = JsonConvert.DeserializeObject<Class>(apiresponse);
            }
            return Classes;
        }
        public static async Task<Class?> CreateClass(Class c)
        {
            Class? classes = new Class();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/Classes", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                classes = JsonConvert.DeserializeObject<Class>(apiresponse);
            }
            return classes;
        }
    }
}
