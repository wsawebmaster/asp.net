using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços de autenticação e autorização
builder.Services.AddAuthentication("Cookies").AddCookie("Cookies", config =>
    {
        config.Cookie.Name = "User.Login.Cookie";
        config.LoginPath = "/Account/Login";
    }
    );

builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
});

builder.Services.AddControllers();

var app = builder.Build();

// Autenticação e autorização
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();