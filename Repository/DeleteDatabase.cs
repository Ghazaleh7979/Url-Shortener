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
        
        // DateTime timeNow = DateTime.UtcNow - new TimeSpan(5,0,0);
        //
        // IQueryable<Urls> remo = _context
        //     .UrlList.Where(d => d.DateTime >= timeNow);

        DateTime nowtime = DateTime.UtcNow;
        var five = nowtime.AddHours(-5);
        
        IQueryable<Urls> remo = _context
             .UrlList.Where(d => d.DateTime <= five);
        

        foreach (var n in remo)
        {
            _context.UrlList.Remove(n);
        }
        _context.SaveChanges();


    }
}