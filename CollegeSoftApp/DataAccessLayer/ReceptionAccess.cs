using CollegeSoftApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class ReceptionAccess
    {
        public static async Task<List<ReceptionView>?> GetReception()
        {
            List<ReceptionView>? receptions = new List<ReceptionView>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/Reception"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    receptions = JsonConvert.DeserializeObject<List<ReceptionView>>(apiresponse);
                }
                return receptions;
            }
            catch
            {
                return receptions;
            }
            //id
            public static async Task<List<ReceptionView?>> GetReception(int id)
            {
                List<ReceptionView>? receptionViews = new List<ReceptionView>();
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/Reception/" + id.ToString()))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    receptionViews = JsonConvert.DeserializeObject<List<ReceptionView>>(apiresponse);
                }
                return receptionViews;
            }
            public static async Task<ReceptionView?> CreateReception(Reception reception)
            {
                ReceptionView? receptionView = new ReceptionView();
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(reception), Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7027/api/Reception", content))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                }
                return receptionView;
            }
        }
    }
}
