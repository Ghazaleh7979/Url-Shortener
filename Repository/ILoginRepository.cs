using UrlShortener.Models.Entity;

namespace UrlShortener.Repository;

public interface ILoginRepository
{
    public  Task<LoginModel> LoginUser(string user, string pass);
}