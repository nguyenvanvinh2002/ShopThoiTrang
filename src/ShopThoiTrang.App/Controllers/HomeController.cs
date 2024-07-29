using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            return View();
        }
    }
}
