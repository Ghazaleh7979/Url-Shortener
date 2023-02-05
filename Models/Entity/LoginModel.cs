namespace UrlShortener.Models.Entity;

public class LoginModel
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;
    
    public string Password { get; set; } = null!;
}