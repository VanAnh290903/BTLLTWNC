using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required(ErrorMessage = "Tên đăng nhập là bắt buộc.")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    
}