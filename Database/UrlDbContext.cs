using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Configurations;
using UrlShortener.Models.Entity;

namespace UrlShortener.DataBase;

public class UrlDbcontext: IdentityDbContext
{
    public UrlDbcontext(DbContextOptions<UrlDbcontext> options)
        : base(options)
    {
    }

    public DbSet<Urls> UrlList { get; set; } = null!;
    
    public DbSet<LoginModel> UserPass { get; set; } = null!;

    public DbSet<SaveKey> KeyList { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UrlsConfiguration());
    }
}