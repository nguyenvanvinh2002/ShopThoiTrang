using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopThoiTrang.API.Data;
using ShopThoiTrang.API.Model;

namespace ShopThoiTrang.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ProductsController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
           
                var lstproducts = _context.SanPhams.ToList();
                return Ok(lstproducts);
            
          
           

        }
        [HttpGet("{IdSp}")]
        public IActionResult FillterById(int IdSp)
        {

            var ftsp = _context.SanPhams.SingleOrDefault(a => a.IdSp == IdSp);
            if (ftsp == null)
            {

                return BadRequest("Không tìm thấy Id phù hợp ");
            }
            else
            {
                return Ok(ftsp);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateProducts(SanPhamsModel model)
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
            _context.Add(lstproducts);
            _context.SaveChanges();
            return Ok("thêm sản phẩm thành công");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{IdSp}")]
        public IActionResult UpdateProducts(int IdSp, SanPhamsModel model)
        {
            var upsp = _context.SanPhams.SingleOrDefault(a => a.IdSp == IdSp);
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
            _context.SaveChanges();
            return Ok("cập nhật thành công");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{IdSp}")]
        public IActionResult DeleteProducts(int IdSp)
        {
            var dlsp = _context.SanPhams.SingleOrDefault(a => a.IdSp == IdSp);
            if (dlsp == null)
            {
                return BadRequest("Không tìm thấy Id sản Phẩm");
            }
            else
            {
                _context.Remove(dlsp);
                _context.SaveChanges();
                return Ok("Xóa Sản Phẩm thành công");
            }
        }
    }
}
