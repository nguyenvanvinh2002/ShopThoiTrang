using System.ComponentModel.DataAnnotations;

namespace ShopThoiTrang.API.Model
{
    public class UsersModel
    {
        [StringLength(50)]
        public string? UserName { get; set; }

        [StringLength(50)]
        public string? PassWord { get; set; }
        [StringLength (50)]
        public string? Roles { get; set; }
       
    }
}
