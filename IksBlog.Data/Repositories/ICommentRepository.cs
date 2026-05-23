using IksBlog.Data.Entities;

namespace IksBlog.Data.Repositories;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetByPostIdAsync(int postId);
    Task AddAsync(Comment comment);
}
