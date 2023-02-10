using UrlShortener.Models.Entity;

namespace UrlShortener.Application;

public interface ILoginApplicatin
{
    public Task<LoginModel?> Check(string user, string pass);

    public Task<string> KeyCheck();

}