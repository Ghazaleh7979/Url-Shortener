using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;

namespace UrlShortener.Controllers;

[ApiController]
[Route("/")]
public class RedirectUrlController : ControllerBase
{
    private readonly IUrlApplication _application;

    public RedirectUrlController(IUrlApplication application)
    {
        _application = application;
    }

    [HttpGet("{idd}")]
    public async Task<ActionResult> RedirectUrl(string idd, CancellationToken cancellationToken)
    {
        try
        {
            var www = await _application.Check(idd, cancellationToken);
            return Redirect(www);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}