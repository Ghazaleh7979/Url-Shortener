using Microsoft.EntityFrameworkCore;
using UrlShortener.DataBase;
using UrlShortener.Models.Dto;
using UrlShortener.Models.Entity;

namespace UrlShortener.Repository;

public class LoginRepository : ILoginRepository
{
    private readonly UrlDbcontext _urlDbContext;

    public LoginRepository(UrlDbcontext urlDbContext)
    {
        _urlDbContext = urlDbContext;
    }

    public async Task<LoginModel?> LoginUser(string user, string pass)
    {
        var uuu =await _urlDbContext.UserPass
            .Where(models => models.UserName == user && models.Password == pass)
            .FirstOrDefaultAsync();
        
        return uuu;
    }

    public void Keys()
    {
        var keys = new GetGuid().GetGuidd();
        SaveKey saveKey = new SaveKey()
        {
            Key = keys
        };
        
        _urlDbContext
            .KeyList
            .AddAsync(saveKey);
        
        _urlDbContext.SaveChanges();
    }
}