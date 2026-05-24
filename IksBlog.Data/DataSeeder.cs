using IksBlog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IksBlog.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(BlogDbContext context)
    {
        if (await context.AppUsers.AnyAsync())
        {
            return;
        }

        context.AppUsers.Add(new AppUser
        {
            UserName = "admin",
            Password = BCrypt.Net.BCrypt.HashPassword("ChangeMe123!")
        });

        await context.SaveChangesAsync();
    }
}
