using System.ComponentModel.DataAnnotations;

namespace IksBlog.Web.Models.ViewModels;

public class ContactViewModel
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Phone { get; set; } = string.Empty;

    [Required]
    public string Message { get; set; } = string.Empty;
}
