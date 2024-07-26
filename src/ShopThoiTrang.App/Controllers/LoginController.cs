using Microsoft.AspNetCore.Mvc;

namespace ShopThoiTrang.App.Controllers
{
    public class LoginController : Controller
    {
        public async Task<IActionResult> Login()
        {
            return View();
        }
    }
}
