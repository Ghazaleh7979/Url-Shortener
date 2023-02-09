using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UrlShortener.DataBase;
using UrlShortener.Models.Dto;
using UrlShortener.Models.Entity;

namespace UrlShortener.Repository;

public class LoginRepository : ILoginRepository
{
    private readonly UrlDbContext _urlDbContext;

    public LoginRepository(UrlDbContext urlDbContext)
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

    public async Task<SaveKey> Keys()
    {
        var keys = new GetGuid().GetGuidd();
        SaveKey saveKey = new SaveKey()
        {
            Key = keys
        };
        
        await _urlDbContext
            .KeyList
            .AddAsync(saveKey);
        
        _urlDbContext.SaveChanges();
        
        return saveKey;
    }
}