using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace Btl_web_nc.Models
{
    [Table("users ")]
    public class User
    {
        //[Key]
        public long userId { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public string? phoneNumber { get; set; }
        public long roleId { get; set; }
        [ForeignKey("roleId")]
        public virtual Role? Role { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
        public virtual ICollection<Favourite>? Favourites { get; set; }
        public virtual ICollection<Notify>? Notifies { get; set; }
    }
}
