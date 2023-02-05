using UrlShortener.Models.Entity;
using UrlShortener.Repository;

namespace UrlShortener.Application;

public class LoginApplicatin : ILoginApplicatin
{
    private ILoginRepository _repository;

    public LoginApplicatin(ILoginRepository repository)
    {
        _repository = repository;
    }

    public async Task<LoginModel> Check(string user, string pass)
    {
        var getUserPas = await _repository.LoginUser(user, pass);
        
        if (getUserPas == null)
        {
            throw new Exception("not found!");
        }

        return getUserPas;
    }
}
    