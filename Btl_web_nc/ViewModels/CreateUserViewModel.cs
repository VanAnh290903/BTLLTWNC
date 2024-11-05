using System.ComponentModel.DataAnnotations;

namespace Btl_web_nc.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "Username là bắt buộc")]
        [StringLength(50, ErrorMessage = "Username không được vượt quá 50 ký tự")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string ConfirmPassword { get; set; }

        public bool IsAdmin { get; set; }
    }
}
