using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Models.Entity;

namespace UrlShortener.Configurations;

public class UrlsConfiguration : IEntityTypeConfiguration<Urls>
{
    public void Configure(EntityTypeBuilder<Urls> builder)
    {
    }
}