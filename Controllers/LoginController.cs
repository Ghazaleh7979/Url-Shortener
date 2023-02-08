
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UrlShortener.Application;
using UrlShortener.Models.Dto;

namespace UrlShortener.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{

    private ILoginApplicatin _application;
    // private IConfiguration _configuration;

    public LoginController(ILoginApplicatin application, IConfiguration configuration)
    {
        _application = application;
        // _configuration = configuration;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginBox(string user, string pass)
    {
        var fff = await _application.Check(user, pass);

        return Ok();

        // if (fff == null)
        // {
        //     return BadRequest(new { message = "Please enter correct User and Pass" });
        // }
        // else
        // {
        //     var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
        //         _configuration["Authentication:SecretForKey"] ?? string.Empty));
        //     var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        //     var tokeOptions = new JwtSecurityToken(
        //         issuer: "https://localhost:7201",
        //         audience: "ShortUrlApi",
        //         claims: new List<Claim>(),
        //         expires: DateTime.Now.AddHours(1),
        //         signingCredentials: signinCredentials
        //     );
        //     var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        //     return Ok(new AuthenticatedResponse { Token = tokenString });
        // }
    }
}