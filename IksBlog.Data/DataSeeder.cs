using IksBlog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IksBlog.Data;

public static class DataSeeder
{
    public static async Task SeedAsync(BlogDbContext context, AuthService auth)
    {
        if (await context.AppUsers.AnyAsync())
        {
            return;
        }

        await auth.CreateUserAsync("iqbal", "password123");
        var author = await context.AppUsers.FirstAsync(u => u.UserName == "iqbal");

        var posts = new List<BlogPost>
        {
            new()
            {
                PostTitle = "Welcome to My Blog",
                PostSubTitle = "Sharing what I know.",
                UserId = author.Id,
                CreatedAt = "2026-05-20T14:00:00Z",
                Content = "<p>Welcome to my personal blog. I will be writing about web development, ASP.NET, and things I learn along the way.</p>"
            },
            new()
            {
                PostTitle = "Migrating from Web Forms to ASP.NET Core",
                PostSubTitle = "A page-centric journey to MVC.",
                UserId = author.Id,
                CreatedAt = "2026-05-18T10:30:00Z",
                Content = "<p>Web Forms served me well for years. Moving to ASP.NET Core MVC brings cleaner separation, EF Core, and modern authentication.</p>"
            },
            new()
            {
                PostTitle = "Entity Framework Core with an Existing Database",
                PostSubTitle = "Mapping legacy tables without migrations.",
                UserId = author.Id,
                CreatedAt = "2026-05-15T09:00:00Z",
                Content = "<p>Fluent API column mapping lets you point EF Core at existing SQL Server tables like Blog, Comments, and Login.</p>"
            },
            new()
            {
                PostTitle = "Cookie Authentication in ASP.NET Core",
                PostSubTitle = "Replacing custom ik_secret cookies.",
                UserId = author.Id,
                CreatedAt = "2026-05-12T16:45:00Z",
                Content = "<p>ASP.NET Core cookie auth with BCrypt password hashing is a big security upgrade over the old SHA1 approach.</p>"
            },
            new()
            {
                PostTitle = "Building a Clean Blog Theme",
                PostSubTitle = "Start Bootstrap and custom pages.",
                UserId = author.Id,
                CreatedAt = "2026-05-10T11:20:00Z",
                Content = "<p>The original site used the Clean Blog theme from Start Bootstrap. The MVC version will reuse that styling in wwwroot.</p>"
            },
            new()
            {
                PostTitle = "Pagination Without Stored Procedures",
                PostSubTitle = "Skip and Take in EF Core.",
                UserId = author.Id,
                CreatedAt = "2026-05-08T08:15:00Z",
                Content = "<p>The legacy blogIndex stored procedure is replaced by GetPagedPostsAsync with OrderByDescending and Skip/Take.</p>"
            },
            new()
            {
                PostTitle = "Comments and Contact Forms",
                PostSubTitle = "Public features on the blog.",
                UserId = author.Id,
                CreatedAt = "2026-05-05T13:00:00Z",
                Content = "<p>Readers can leave comments on posts and send messages through the contact page. Both write to SQL Server via repositories.</p>"
            }
        };

        context.BlogPosts.AddRange(posts);
        await context.SaveChangesAsync();

        var firstPost = posts[0];
        var secondPost = posts[1];

        context.Comments.AddRange(
            new Comment
            {
                PostId = firstPost.Id,
                Name = "Jane Reader",
                Email = "jane@example.com",
                CommentText = "Great to see the blog live on ASP.NET Core!"
            },
            new Comment
            {
                PostId = firstPost.Id,
                Name = "Alex Dev",
                Email = "alex@example.com",
                CommentText = "Looking forward to more posts about the migration."
            },
            new Comment
            {
                PostId = secondPost.Id,
                Name = "Sam Coder",
                Email = "sam@example.com",
                CommentText = "MVC is a natural fit for this kind of site."
            });

        context.ContactMessages.Add(new ContactMessage
        {
            Name = "Sample Visitor",
            Email = "visitor@example.com",
            Phone = "555-0100",
            Message = "This is sample contact data seeded for local development."
        });

        await context.SaveChangesAsync();
    }
}
