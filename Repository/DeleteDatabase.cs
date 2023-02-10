using UrlShortener.DataBase;
using UrlShortener.Models.Entity;

namespace UrlShortener.Repository;

public class DeleteDatabase : IDeleteDatabase
{
    private UrlDbContext _context;

    public DeleteDatabase(UrlDbContext context)
    {
        _context = context;
    }

    public void DeleteData()
    {
        var timeNow = DateTime.UtcNow;

        IQueryable<Urls> remo = _context
            .UrlList.Where(d => timeNow.Hour - d.DateTime.Hour >= 5 || d.DateTime.Day != timeNow.Day);

        foreach (var n in remo)
        {
            _context.UrlList.Remove(n);
        }
        _context.SaveChanges();


    }
}