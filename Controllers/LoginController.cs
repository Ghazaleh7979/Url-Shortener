
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;
using UrlShortener.Models.Entity;


namespace UrlShortener.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{

    private readonly ILoginApplicatin _application;

    public LoginController(ILoginApplicatin application)
    {
        _application = application;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginBox(string user, string pass)
    {
        var fff = await _application.Check(user, pass);

        if (fff != null)
        {
            var resp =await _application.KeyCheck();
            
            return Ok(resp) ;
        }
        
        return BadRequest(new { message = "Please enter correct User and Pass" });
        
    }
}