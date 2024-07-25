using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopThoiTrang.API.Data
{
    [Table("User")]
    public class Users
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

    }
}
