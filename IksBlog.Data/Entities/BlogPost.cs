namespace IksBlog.Data.Entities;

public class BlogPost
{
    public int Id { get; set; }
    public string PostTitle { get; set; } = string.Empty;
    public string PostSubTitle { get; set; } = string.Empty;
    public int UserId { get; set; }
    public string CreatedAt { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}