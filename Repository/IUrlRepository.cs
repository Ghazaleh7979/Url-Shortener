using UrlShortener.Models.Entity;

namespace UrlShortener.Repository;

public interface IUrlRepository
{
    public Task<Urls?> GetLongUrl(string lu, CancellationToken cancellationToken);

    public Task<Urls?> GetShortUrl(string shu, CancellationToken cancellationToken);
}