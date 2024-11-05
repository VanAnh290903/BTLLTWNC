using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Btl_web_nc.Models
{
    [Table("types")]
    public class Type
    {
        [Key]
        public long? typeId { get; set; }
        public string? typeName { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
    }
}
