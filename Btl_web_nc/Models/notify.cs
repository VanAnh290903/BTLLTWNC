using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Btl_web_nc.Models
{
    [Table("notifies")]
    public class Notify
    {
        [Key]
        public long notifyId { get; set; }
        public long userId { get; set; }
        public long postId { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập nội dung thông báo!")]
        public string? content { get; set; }
        [ForeignKey("userId")]
        public virtual User? User { get; set; }
        [ForeignKey("postId")]
        public virtual Post? Post { get; set; }
    }
}
