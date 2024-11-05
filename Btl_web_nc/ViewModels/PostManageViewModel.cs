using System.ComponentModel.DataAnnotations;
using Btl_web_nc.Models;

public class PostManageViewModel
{
    public string? TypeName { get; set; }
    public long PostId { get; set; }

    [Required(ErrorMessage = "Tiêu đề là bắt buộc.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "Mô tả là bắt buộc.")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "Diện tích là bắt buộc.")]
    public long? Area { get; set; }

    [Required(ErrorMessage = "Giá là bắt buộc.")]
    [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn 0.")]
    public long Price { get; set; }

    [Required(ErrorMessage = "Trạng thái là bắt buộc.")]
    public string? Status { get; set; }

    [Required(ErrorMessage = "Ảnh đại diện là bắt buộc.")]
    public string? ImageUrls { get; set; } // Thay đổi thành List<string>?

    public long TypeId { get; set; } 

    public DateTime CreateDate{ get; set; } 

    public PostManageViewModel()
    {
        
    }
    public PostManageViewModel(Post post)
    {
        // Map các thuộc tính từ Post sang PostViewModel
        PostId = post.postId;
        Title = post.title;
        Address = post.address;
        Description = post.description;
        Price = post.price;
        Status = post.status;
        ImageUrls = post.imageUrls;// != null ? new List<string>(post.imageUrls) : new List<string>();
        TypeId = post.typeId;
        Area  = post.area;
        CreateDate = post.createdDate;
    }
}