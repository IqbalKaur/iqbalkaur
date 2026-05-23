namespace IksBlog.Data.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CommentText { get; set; } = string.Empty;
    public int PostId { get; set; }
}