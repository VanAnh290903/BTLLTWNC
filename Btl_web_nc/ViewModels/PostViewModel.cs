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
    }
