using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Application.Abstractions.Services;
using YurttaYe.Application.Common;
using YurttaYe.Application.Services;
using YurttaYe.Infrastructure.Persistence;
using YurttaYe.Infrastructure.Persistence.Repositories;
using YurttaYe.Infrastructure.Services;
using YurttaYe.WebApi.Middleware;
using MediatR;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient(); // Register IHttpClientFactory for LoginModel
builder.Services.AddSession(options => // Add session support
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQLite Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFileProcessingService, FileProcessingService>();

// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(Program).Assembly,
    typeof(YurttaYe.Application.Common.Result).Assembly));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
        };
    });

builder.Services.AddAuthorization();

// CORS (optional)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseSession(); // Enable session middleware
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();

app.Run();