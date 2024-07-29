using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopThoiTrang.API.Data;
using ShopThoiTrang.API.Model.Users;
using System.Data;


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
        public async Task<IActionResult> GetAllUser(int PageNumber = 1,int PageSize =3)
        {
            
            var alluser =await _context.Users.Skip((PageNumber-1)* PageSize).Take(PageSize).ToListAsync();
            
            return Ok(alluser);
        }
        [HttpPut("UpdateUserRole/{Id}")]
        public async Task<IActionResult> UpdateUserRole(int Id, UsersModel role)
        {
            var IdRl =await _context.Users.SingleOrDefaultAsync(x => x.Id == Id);
            if (IdRl == null)
            {
                return BadRequest("Không tìm thấy Id này");

            }
            else
            {

                IdRl.Roles = role.Roles;

            }
           await _context.SaveChangesAsync();
            return Ok("Cập nhật thành công");

        }
        [HttpPut("UpdateUserStatus/{Id}")]
        public async Task<IActionResult> UpdateUserStatus(int Id , UsersModel status)
        {
            var IdSt = await _context.Users.SingleOrDefaultAsync(x => x.Id == Id);
            if (IdSt == null)
            {
                return BadRequest("Không tìm thấy Id này");

            }
            else
            {

                IdSt.Status = status.Status;

            }
            await _context.SaveChangesAsync();
            return Ok("Cập nhật thành công");

        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleUser(int Id)
        {
            
            var DlUs = await _context.Users.SingleOrDefaultAsync(x => x.Id == Id);
            if(DlUs == null)
            {
                return BadRequest("Không tìm thấy Id này");
            }
            if(DlUs.UserName == "Admin")
            {
                return BadRequest("Bạn không thể xóa tài khoản này");
            }
            else
            {
                _context.Users.Remove(DlUs);
              await  _context.SaveChangesAsync();
                return Ok("Xóa thành công");
            }
        }


    }
}
