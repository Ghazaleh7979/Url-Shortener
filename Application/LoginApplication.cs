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

    public async Task<LoginModel?> Check(string user, string pass)
    {
        var getUserPas = await _repository.LoginUser(user, pass);

        return getUserPas;
    }
    


    public async Task<string> KeyCheck()
    {
        var query =await _repository.Keys();
        
        return query;
    }
}
    