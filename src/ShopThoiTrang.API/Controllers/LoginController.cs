using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ShopThoiTrang.API.Data;
using ShopThoiTrang.API.Model;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopThoiTrang.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(MyDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login(UsersModel user)
        {
            var check = _context.Users.SingleOrDefault(x => x.UserName == user.UserName && x.PassWord == user.PassWord);
            if (check == null) {
                return BadRequest("Tài khoản hoặc mật khẩu không đúng");
            }
            //new token JWT
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub , _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim("UserId", check.Id.ToString()),
                new Claim("UserName", check.UserName),
                new Claim("Roles",check.Roles)


            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var Login = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                 _configuration["Jwt:Issuer"],
                 _configuration["Jwt:Audience"],
                 claims,
                 expires : DateTime.UtcNow.AddMinutes(60),
                 signingCredentials: Login
                );
            string tokenvalue = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new {token = tokenvalue,User = check});
        }
    }
}
