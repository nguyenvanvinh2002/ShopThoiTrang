using System.ComponentModel.DataAnnotations;

namespace ShopThoiTrang.API.Model.Users
{
    public class UserRole
    {
        [StringLength(50)]
        public string? Roles { get; set; }

      

    }
}
