using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Internal.TypeHandlers;
using UrlShortener.Application;
using UrlShortener.Models.Entity;

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

    [HttpPost]
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
                return Redirect("www.google.com");
            }
        }

        return BadRequest(new { message = "Please enter your User and Pass" });

    }

}