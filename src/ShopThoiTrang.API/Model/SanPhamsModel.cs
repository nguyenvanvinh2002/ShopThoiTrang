using System.ComponentModel.DataAnnotations;

namespace ShopThoiTrang.API.Model
{
    public class SanPhamsModel
    {
        public string? TenSp { get; set; }

        [StringLength(50)]
        public string? DanhMucSp { get; set; }

        [StringLength(50)]
        public string? HinhPhu { get; set; }

        [StringLength(50)]
        public string? HinhPhu1 { get; set; }

        public int? GiaSp { get; set; }

        [StringLength(50)]
        public string? Img { get; set; }

        public string? Mota { get; set; }
    }
}
