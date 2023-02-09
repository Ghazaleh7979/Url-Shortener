namespace UrlShortener.Models.Entity;

public class Urls
{
    public int Id { get; set; }
    public string LongUrl { get; set; } = null!;
    public string? ShortUrl { get; set; } = null!;
}