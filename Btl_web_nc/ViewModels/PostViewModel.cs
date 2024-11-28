using System.ComponentModel.DataAnnotations;

    public class PostViewModel
    {
        public string? Type { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Tiêu đề là bắt buộc.")]
        public string? Title { get; set; }
        public string? Description { get; set; }

        [Required(ErrorMessage = "Diện tích không được để trống.")]
        public long? Area { get; set; }
        [Required(ErrorMessage = "Mức giá không được để trống.")]
        public long? Price { get; set; }

        [Required(ErrorMessage = "Hình ảnh là bắt buộc")]
        public string? ImageUrls { get; set; }

        // VerifyKey, yêu cầu phải có ít nhất 6 ký tự và kết thúc bằng 1 chữ số
        // ^: Bắt đầu chuỗi.
        // .{5,}:
        //     .: Bất kỳ ký tự nào.
        //     {5,}: Ít nhất 5 ký tự (vì ký tự cuối cùng là số, nên tổng là ít nhất 6 ký tự).
        // [0-9]:
        //     Ký tự cuối cùng phải là một chữ số.
        // $: Kết thúc chuỗi.
        [RegularExpression(@"^.{5,}[0-9]$", ErrorMessage = "VerifyKey phải có ít nhất 6 ký tự và kết thúc bằng một chữ số")]
        public string? VerifyKey { get; set; }

    }
