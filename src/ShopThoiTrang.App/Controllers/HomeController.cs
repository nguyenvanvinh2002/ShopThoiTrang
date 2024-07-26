using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopThoiTrang.App.Models;
using System.Diagnostics;

namespace ShopThoiTrang.App.Controllers
{
    public class HomeController : Controller

    {
        private readonly HttpClient _httpClient;
        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async  Task<IActionResult> Index()
        {
            List<Products> products = new List<Products>();
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:44353/api/Products");
            if (response.IsSuccessStatusCode) { 
            
            var data = await response.Content.ReadAsStringAsync();
                products =  JsonConvert.DeserializeObject<List<Products>>(data);
            }
            return View(products);
        }
    }
}
