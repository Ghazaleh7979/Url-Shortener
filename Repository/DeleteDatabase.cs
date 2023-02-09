using UrlShortener.DataBase;
using UrlShortener.Models.Entity;

namespace UrlShortener.Repository;

public class DeleteDatabase
{
    private UrlDbContext _context;

    public DeleteDatabase(UrlDbContext context)
    {
        _context = context;
    }
    
}