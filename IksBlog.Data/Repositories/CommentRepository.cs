using IksBlog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IksBlog.Data.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly BlogDbContext _context;

    public CommentRepository(BlogDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Comment>> GetByPostIdAsync(int postId)
    {
        return await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
    }

    public async Task AddAsync(Comment comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
    }
}
