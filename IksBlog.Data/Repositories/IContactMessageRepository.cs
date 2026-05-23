using IksBlog.Data.Entities;

namespace IksBlog.Data.Repositories;

public interface IContactMessageRepository
{
    Task AddAsync(ContactMessage contactMessage);
}
