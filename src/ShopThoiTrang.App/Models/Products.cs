using System.ComponentModel.DataAnnotations;

namespace ShopThoiTrang.App.Models
{
    public class Products
    {
        public int IdSp { get; set; }
        public string? TenSp { get; set; }

        [StringLength(50)]
        public string? DanhMucSp { get; set; }

        [StringLength(50)]
        public string? HinhPhu { get; set; }

        [StringLength(50)]
        public string? HinhPhu1 { get; set; }

        public int? GiaSp { get; set; }
        public int? DaBan { get; set; } = 0;

        [StringLength(50)]
        public string? Img { get; set; }

        public string? Mota { get; set; }
    }

}
