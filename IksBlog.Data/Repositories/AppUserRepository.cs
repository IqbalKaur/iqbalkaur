using IksBlog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IksBlog.Data.Repositories;

public class AppUserRepository : IAppUserRepository
{
    private readonly BlogDbContext _context;

    public AppUserRepository(BlogDbContext context)
    {
        _context = context;
    }

    public async Task<AppUser?> GetByUserNameAsync(string userName)
    {
        return await _context.AppUsers.FirstOrDefaultAsync(u => u.UserName == userName);
    }

    public async Task AddAsync(AppUser appUser)
    {
        _context.AppUsers.Add(appUser);
        await _context.SaveChangesAsync();
    }
}
