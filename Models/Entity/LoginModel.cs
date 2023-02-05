using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models.Entity;

public class LoginModel
{
    public int Id { get; set; }
    
    [Required]
    public string UserName { get; set; } = "Ghazaleh";
    
    [Required]
    public string Password { get; set; } = "Ghazaleh";
}