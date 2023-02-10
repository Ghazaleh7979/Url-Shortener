using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Repository;

namespace UrlShortener.Controllers;
[ApiController]
[Route("api/[controller]")]


public class GetController : ControllerBase
{
    private readonly IUrlRepository _repository;

    public GetController(IUrlRepository repository, ILoginRepository loginRepository)
    {
        _repository = repository;
    }

    
    [HttpGet]
    public async Task<ActionResult<string>> Show(string key,string ll , CancellationToken cancellationToken)
    {
        var last = _repository.ValiSaveKey();
        if (last.Key == key)
        {
            var full =(await _repository.GetLongUrl(ll, cancellationToken))?.ShortUrl;

            if (full != null)
            {
                return Ok( $"https://localhost:7201/{full}");
            }
            else
            {
                return BadRequest("First Enter Long Url ");
            }
        }

        return BadRequest("Please Login and enter your input key");
    }
}