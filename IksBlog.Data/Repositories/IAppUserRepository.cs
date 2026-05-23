using IksBlog.Data.Entities;

namespace IksBlog.Data.Repositories;

public interface IAppUserRepository
{
    Task<AppUser?> GetByUserNameAsync(string userName);
    Task AddAsync(AppUser appUser);
}
