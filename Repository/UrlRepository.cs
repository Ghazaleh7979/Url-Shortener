using Microsoft.EntityFrameworkCore;
using UrlShortener.DataBase;
using UrlShortener.Models.Dto;
using UrlShortener.Models.Entity;

namespace UrlShortener.Repository;

public class UrlRepository : IUrlRepository
{
    private readonly UrlDbcontext _dbContext;

    public UrlRepository(UrlDbcontext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Urls?> GetLongUrl(string lu, CancellationToken cancellationToken)
    {
        var urls = new Urls
        {
            LongUrl = lu
        };

        var shu = new GetGuid().GetGuidd();
        

        urls.ShortUrl = shu;


        await _dbContext.UrlList.AddAsync(urls, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return urls;
    }

    public async Task<Urls?> GetShortUrl(string shu, CancellationToken cancellationToken)
    {
        var resultUrl = await _dbContext.UrlList.Where(u => u.ShortUrl == shu).FirstOrDefaultAsync(cancellationToken);
        return resultUrl;
    }
}