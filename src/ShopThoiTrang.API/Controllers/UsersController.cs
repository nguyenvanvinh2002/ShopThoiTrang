using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopThoiTrang.API.Data;
using ShopThoiTrang.API.Model;

namespace ShopThoiTrang.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _context;
        public UsersController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {

            var alluser = _context.Users.ToList();
            return Ok(alluser);
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateUser(int Id, UsersModel users)
        {
            var IdUs = _context.Users.SingleOrDefault(x => x.Id == Id);
            if (IdUs == null)
            {
                return BadRequest("Không tìm thấy Id này");

            }
            else
            {

                IdUs.Roles = users.Roles;

            }
            _context.SaveChanges();
            return Ok("Cập nhật thành công");

        }
        [HttpDelete("{Id}")]
        public IActionResult DeleteUser(int Id) {

            var Dlus = _context.Users.SingleOrDefault(x => x.Id == Id);
            if (Dlus == null) {
                return BadRequest("Không tìm thấy Id này");
            }
            else
            {
                _context.Remove(Dlus);
                _context.SaveChanges();
                return Ok("Xóa thành công");
            }
        
        }
    }
}
