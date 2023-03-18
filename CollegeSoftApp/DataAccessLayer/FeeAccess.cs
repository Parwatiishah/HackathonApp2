using CollegeSoftApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CollegeSoftApp.DataAccessLayer
{
    public static partial class FeeAccess
    {
        public static async Task<List<Fee>?> GetFee()
        {

            List<Fee>? Fees = new List<Fee>();
            try
            {
                HttpClient client = new HttpClient();
                using (var response = await client.GetAsync("https://localhost:7027/api/Fees"))
                {
                    string apiresponse = await response.Content.ReadAsStringAsync();
                    Fees = JsonConvert.DeserializeObject<List<Fee>>(apiresponse);
                }
                return Fees;
            }
            catch
            {
                return Fees;
            }
        }
        //id
        public static async Task<List<FeeDetailsView?>> GetFeeDetails(int id)
        {
            List<FeeDetailsView>? feeDetails = new List<FeeDetailsView>();
            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync("https://localhost:7027/api/FeeDetails/" + id.ToString()))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
                feeDetails = JsonConvert.DeserializeObject<List<FeeDetailsView>>(apiresponse);
            }
            return feeDetails;
        }
        public static async Task<FeeEdit?> CreateFee(FeeEdit feeEdit)
        {
            FeeEdit? feeEdits = new FeeEdit();
            HttpClient client = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(feeEdit), Encoding.UTF8, "application/json");
            using (var response = await client.PostAsync("https://localhost:7027/api/Fees", content))
            {
                string apiresponse = await response.Content.ReadAsStringAsync();
            }
            return feeEdits;
        }
    }
}
