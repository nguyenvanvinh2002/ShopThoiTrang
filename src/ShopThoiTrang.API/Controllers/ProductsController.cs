using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ShopThoiTrang.API.Data;
using ShopThoiTrang.API.Model;
using System.Linq;

namespace ShopThoiTrang.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly PageSize _pageSize;
        public ProductsController(MyDbContext context, IOptions<PageSize> pageSize)
        {
            _context = context;
            _pageSize = pageSize.Value;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(int? pageNumber ,int? pageSize  )
        {
            int pageNum = pageNumber ?? _pageSize.PageNumber;
            int pageSizeNum = pageSize ?? _pageSize.PageSizeNumber;


            var lstproducts = await _context.SanPhams.Skip((pageNum - 1) * pageSizeNum).Take(pageSizeNum).ToListAsync();
      
            return Ok(lstproducts);

        }
        [HttpGet("{danhMucSp}")]
        public async Task<IActionResult> FillterById(string danhMucSp, int pageNumber = 1 ,int pageSize = 3)
        {

            var ftsp = await _context.SanPhams.Where(a => a.DanhMucSp == danhMucSp).Skip((pageNumber - 1)* pageSize).Take(pageSize).ToListAsync();
            if (ftsp == null || !ftsp.Any())
            {

                return BadRequest("Không tìm thấy sản phẩm phù hợp ");
            }
            else
            {
                return Ok(ftsp);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateProducts(SanPhamsModel model)
        {
            var lstproducts = new SanPhams
            {
                TenSp = model.TenSp,
                DanhMucSp = model.DanhMucSp,
                Img = model.Img,
                HinhPhu = model.HinhPhu,
                HinhPhu1 = model.HinhPhu1,
                GiaSp = model.GiaSp,
                Mota = model.Mota
            };
          await  _context.AddAsync(lstproducts);
           await _context.SaveChangesAsync();
            return Ok("thêm sản phẩm thành công");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{IdSp}")]
        public async Task<IActionResult> UpdateProducts(int IdSp, SanPhamsModel model)
        {
            var upsp = await _context.SanPhams.SingleOrDefaultAsync(a => a.IdSp == IdSp);
            if (upsp == null)
            {
                return BadRequest("Không tìm thấy Id sản phẩm");
            }
            else
            {
                upsp.TenSp = model.TenSp;
                upsp.DanhMucSp = model.DanhMucSp;
                upsp.Img = model.Img;
                upsp.HinhPhu = model.HinhPhu;
                upsp.HinhPhu1 = model.HinhPhu1;
                upsp.GiaSp = model.GiaSp;
                upsp.Mota = model.Mota;
            }
           await _context.SaveChangesAsync();
            return Ok("cập nhật thành công");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{IdSp}")]
        public async Task<IActionResult> DeleteProducts(int IdSp)
        {
            var dlsp = await _context.SanPhams.SingleOrDefaultAsync(a => a.IdSp == IdSp);
            if (dlsp == null)
            {
                return BadRequest("Không tìm thấy Id sản Phẩm");
            }
            else
            {
                _context.Remove(dlsp);
                await  _context.SaveChangesAsync();
                return Ok("Xóa Sản Phẩm thành công");
            }
        }
    }
}
