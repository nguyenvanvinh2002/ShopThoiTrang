using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopThoiTrang.API.Data;
using ShopThoiTrang.API.Model.Users;

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
        public async Task<IActionResult> RegiterUser(UsersModel acc)
        {
            

            if (string.IsNullOrWhiteSpace(acc.UserName) || string.IsNullOrWhiteSpace(acc.PassWord))
            {
                return BadRequest("Không được để trống tên người dùng hoặc mật khẩu.");
            }
            var check = await _context.Users.AnyAsync(x => x.UserName == acc.UserName);
            if (check)
            {
                return BadRequest("Tài khoản đã tồn tại");
            }
            var newUser = new Users
            {
                UserName = acc.UserName,
                PassWord = acc.PassWord

                
            };

            await _context.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return Ok("Đăng ký thành công");

        }
    }
}

