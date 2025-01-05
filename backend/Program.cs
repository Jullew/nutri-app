using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NutriApp.Data;
using NutriApp.DTOs.Requests;
using NutriApp.Middleware;
using NutriApp.Repositories;
using NutriApp.Repositories.Interfaces;
using NutriApp.Services;
using NutriApp.Services.Interfaces;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Rejestracja DbContext z użyciem PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Konfiguracja logowania
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

Env.Load();



//FluentValidation
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterRequestValidator>());

builder.Services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
builder.Services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();


// Konfiguracja JWT
var jwtKey = Env.GetString("JWT_SECRET");

if (string.IsNullOrEmpty(jwtKey))
{
    throw new InvalidOperationException("JWT_SECRET is not set in the environment variables.");
}

var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Rejestracja kontrolerów i usług
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Sprawdzenie połączenia z bazą
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        Console.WriteLine("🔍  Sprawdzanie połączenia do bazy danych...");
        dbContext.Database.OpenConnection();
        Console.WriteLine("✅  Połączenie do bazy danych jest poprawne!");
        dbContext.Database.CloseConnection();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌  Błąd połączenia z bazą danych: {ex.Message}");
    }
}


// Middleware obsługi wyjątków
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting(); // Middleware routingu powinno być przed autoryzacją

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // Usunięcie powielonego app.MapControllers()

app.Run();
