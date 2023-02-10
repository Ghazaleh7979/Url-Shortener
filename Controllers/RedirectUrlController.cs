using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;
using UrlShortener.Repository;

namespace UrlShortener.Controllers;

[ApiController]
[Route("/")]
public class RedirectUrlController : ControllerBase
{
    private readonly IUrlApplication _application;
    private readonly IDeleteDatabase _delete;

    public RedirectUrlController(IUrlApplication application, IDeleteDatabase delete)
    {
        _application = application;
        _delete = delete;
    }

    [HttpGet("{idd}")]
    public async Task<ActionResult> RedirectUrl(string idd, CancellationToken cancellationToken)
    {
        _delete.DeleteData();
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