using IksBlog.Data.Entities;

namespace IksBlog.Data.Repositories;

public interface IBlogRepository
{
    Task<List<BlogPost>> GetPagedPostsAsync(int page, int pageSize);
    Task<int> GetTotalPostCountAsync();
    Task<BlogPost?> GetPostByIdAsync(int id);
    Task<int> GetCommentCountForPostAsync(int postId);
    Task CreatePostAsync(BlogPost post);
    Task UpdatePostAsync(BlogPost post);
    Task DeletePostAsync(int id);
    Task AddCommentAsync(Comment comment);
    Task SaveContactMessageAsync(ContactMessage message);
}
