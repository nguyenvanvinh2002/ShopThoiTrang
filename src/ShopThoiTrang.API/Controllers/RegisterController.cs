using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopThoiTrang.API.Data;
using ShopThoiTrang.API.Model;

namespace ShopThoiTrang.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly MyDbContext _context;
        public RegisterController(MyDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult RegiterUser(UsersModel acc)

            
        {
            

            if (string.IsNullOrWhiteSpace(acc.UserName) || string.IsNullOrWhiteSpace(acc.PassWord))
            {
                return BadRequest("Không được để trống tên người dùng hoặc mật khẩu.");
            }
            var check = _context.Users.Any(x => x.UserName == acc.UserName);
            if (check)
            {
                return BadRequest("Tài khoản đã tồn tại");
            }
            var newUser = new Users
            {
                UserName = acc.UserName,
                PassWord = acc.PassWord
            };

            _context.Add(newUser);
            _context.SaveChanges();
            return Ok("Đăng ký thành công");

        }
    }
}

