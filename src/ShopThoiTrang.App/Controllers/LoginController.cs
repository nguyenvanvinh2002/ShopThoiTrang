using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopThoiTrang.App.Models;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace ShopThoiTrang.App.Controllers
{
    public class LoginController : Controller
    {
		
		public IActionResult Login()
		{
			return View();
		}
		
		



    }
}
