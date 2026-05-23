using IksBlog.Data.Entities;

namespace IksBlog.Data.Repositories;

public class ContactMessageRepository : IContactMessageRepository
{
    private readonly BlogDbContext _context;

    public ContactMessageRepository(BlogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ContactMessage contactMessage)
    {
        _context.ContactMessages.Add(contactMessage);
        await _context.SaveChangesAsync();
    }
}
