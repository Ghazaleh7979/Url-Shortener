using Microsoft.EntityFrameworkCore;
using UrlShortener.DataBase;
using UrlShortener.Models.Entity;

namespace UrlShortener.Repository;

public class LoginRepository : ILoginRepository
{
    private UrlDbcontext _urlDbContext;

    public LoginRepository(UrlDbcontext urlDbContext)
    {
        _urlDbContext = urlDbContext;
    }

    public async Task<LoginModel> LoginUser(string user, string pass)
    {
        var uuu =await _urlDbContext.UserPass
            .Where(models => models.UserName == user && models.Password == pass)
            .FirstOrDefaultAsync();
        
        return uuu;
    }
    
}