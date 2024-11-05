using System.ComponentModel.DataAnnotations;

namespace Btl_web_nc.ViewModels
{
    public class ProfileViewModel
    {
        public string Username { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Mật khẩu mới không khớp.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

}
