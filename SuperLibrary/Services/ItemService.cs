using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SuperLibrary.Models;

namespace SuperLibrary.Services
{
    public class ItemService
    {
        private readonly HttpClient client;

        public ItemService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://apiportf20230622023836.azurewebsites.net/"); 
        }

        public async Task<List<PortfolioItem>> GetPortfolioItems()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("");
                response.EnsureSuccessStatusCode();
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<ResponseObject>(responseContent);
                return responseObject.Value;
            }
            catch (Exception ex)
            {
                // Handle exception
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }

    public class ResponseObject
    {
        public List<PortfolioItem> Value { get; set; }
    }
}
