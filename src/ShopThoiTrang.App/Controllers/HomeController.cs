using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopThoiTrang.App.Models;
using System.Diagnostics;

namespace ShopThoiTrang.App.Controllers
{
    public class HomeController : Controller

    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
