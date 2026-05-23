using IksBlog.Data.Entities;

namespace IksBlog.Web.Models.ViewModels;

public class BlogIndexViewModel
{
    public List<BlogPost> Posts { get; set; } = new();
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
