using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Btl_web_nc.Models
{
    [Table("roles")]
    public class Role 
    {
        [Key]
        public long roleId { get; set; }
        public string? roleName { get; set; }
        public virtual ICollection<User>? Users { get; set; }
    }
}
