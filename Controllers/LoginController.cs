
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;

namespace UrlShortener.Controllers;

[ApiController]
[Route("")]
public class LoginController : ControllerBase
{

    private ILoginApplicatin _applicatin;

    public LoginController(ILoginApplicatin applicatin)
    {
        _applicatin = applicatin;
    }

    [HttpPost("/Login")]
    public async Task<IActionResult> LoginBox(string user, string pass)
    {
        if (ModelState.IsValid)
        {
            var fff = await _applicatin.Check(user, pass);

            if (fff == null)
            {
                return BadRequest(new { message ="Please enter correct User and Pass"});
            }
            else
            {
                return Ok();
            }
        }
        else
        {
            return BadRequest(new { message = "Please enter your User and Pass" });
        }

    }

}