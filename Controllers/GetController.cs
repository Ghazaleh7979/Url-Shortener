using Microsoft.AspNetCore.Mvc;
using UrlShortener.Repository;

namespace UrlShortener.Controllers;
[ApiController]
[Route("[controller]")]
public class GetController : ControllerBase
{
    private readonly IUrlRepository _repository;

    public GetController(IUrlRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("GetShortenedUrl")]
    public async Task<ActionResult<string>> Show(string ll, CancellationToken cancellationToken)
    {
        var full =(await _repository.GetLongUrl(ll, cancellationToken))?.ShortUrl;
        return Ok( $"https://localhost:7201/{full}");
    }
}