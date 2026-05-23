using IksBlog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IksBlog.Data.Repositories;

public class BlogPostRepository : IBlogPostRepository
{
    private readonly BlogDbContext _context;

    public BlogPostRepository(BlogDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BlogPost>> GetAllAsync()
    {
        return await _context.BlogPosts.ToListAsync();
    }

    public async Task<BlogPost?> GetByIdAsync(int id)
    {
        return await _context.BlogPosts.FindAsync(id);
    }

    public async Task AddAsync(BlogPost blogPost)
    {
        _context.BlogPosts.Add(blogPost);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BlogPost blogPost)
    {
        _context.BlogPosts.Update(blogPost);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var blogPost = await _context.BlogPosts.FindAsync(id);
        if (blogPost != null)
        {
            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
        }
    }
}
