namespace UrlShortener.Application;

public interface IUrlApplication
{
    public Task<string> Check(string lu, CancellationToken cancellationToken);
    
}