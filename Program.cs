using Microsoft.EntityFrameworkCore;
using UrlShortener.Application;
using UrlShortener.DataBase;
using UrlShortener.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UrlDbcontext>(opts => {
    opts.UseNpgsql(
        builder.Configuration.GetConnectionString("UrlConnection")!);
});
builder.Services.AddScoped<IUrlRepository, UrlRepository>();
builder.Services.AddScoped<IUrlApplication, UrlApplication>();
builder.Services.AddScoped<ILoginApplicatin, LoginApplicatin>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();