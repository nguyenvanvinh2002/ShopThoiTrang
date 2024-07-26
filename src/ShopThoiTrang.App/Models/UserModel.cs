using System.ComponentModel.DataAnnotations;

namespace ShopThoiTrang.App.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string? PassWord { get; set; }
        [StringLength(50)]
        public string? Roles { get; set; } = "User";
        public int? Status { get; set; }
    }
}
