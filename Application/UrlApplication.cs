using UrlShortener.Repository;

namespace UrlShortener.Application;

public class UrlApplication : IUrlApplication
{
    private readonly IUrlRepository _repository;

    public UrlApplication(IUrlRepository repository)
    {
        _repository = repository;
    }

    public async Task<string> Check(string idd, CancellationToken cancellationToken)
    {
        var urls = await _repository.GetShortUrl(idd, cancellationToken);
        if (urls == null)
        {
            throw new Exception("Link not found!");
        }

        return urls.LongUrl;
    }
}