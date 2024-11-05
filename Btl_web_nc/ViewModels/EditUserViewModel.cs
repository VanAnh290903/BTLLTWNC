using System.ComponentModel.DataAnnotations;

namespace Btl_web_nc.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên người dùng là bắt buộc")]
        [StringLength(50, ErrorMessage = "Tên người dùng không được vượt quá 50 ký tự")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }
    }
}
