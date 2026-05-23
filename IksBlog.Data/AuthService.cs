using IksBlog.Data.Entities;
using IksBlog.Data.Repositories;

namespace IksBlog.Data;

public class AuthService
{
    private readonly BlogDbContext _context;
    private readonly IAppUserRepository _userRepository;

    public AuthService(BlogDbContext context, IAppUserRepository userRepository)
    {
        _context = context;
        _userRepository = userRepository;
    }

    public async Task<AppUser?> ValidateCredentialsAsync(string username, string password)
    {
        var user = await _userRepository.GetByUserNameAsync(username);
        if (user == null)
        {
            return null;
        }

        if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            return null;
        }

        return user;
    }

    public async Task<bool> CreateUserAsync(string username, string password)
    {
        if (UsernameExists(username))
        {
            return false;
        }

        var user = new AppUser
        {
            UserName = username,
            Password = BCrypt.Net.BCrypt.HashPassword(password)
        };

        await _userRepository.AddAsync(user);
        return true;
    }

    public bool UsernameExists(string username)
    {
        return _context.AppUsers.Any(u => u.UserName == username);
    }
}
