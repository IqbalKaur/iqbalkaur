using System.ComponentModel.DataAnnotations;

namespace IksBlog.Web.Models.ViewModels;

public class CreatePostViewModel
{
    [Required]
    public string PostTitle { get; set; } = string.Empty;

    [Required]
    public string PostSubTitle { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;
}
