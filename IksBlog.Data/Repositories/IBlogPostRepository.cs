using IksBlog.Data.Entities;

namespace IksBlog.Data.Repositories;

public interface IBlogPostRepository
{
    Task<IEnumerable<BlogPost>> GetAllAsync();
    Task<BlogPost?> GetByIdAsync(int id);
    Task AddAsync(BlogPost blogPost);
    Task UpdateAsync(BlogPost blogPost);
    Task DeleteAsync(int id);
}
