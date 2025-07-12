using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SportReserve_Shared.Models;
using SportReserveDatabase;
using SportReserveDatabase.Entities;
using SportReserveServer;
using SportReserveServer.CompositionRoot;
using SportReserveServer.Interfaces;
using SportReserveServer.Interfaces.Aggregates;
using SportReserveServer.Interfaces.Base;
using SportReserveServer.Middleware;
using SportReserveServer.Repositories;
using SportReserveServer.Services;
using SportReserveServer.Validators;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var authenticationSettings = new AuthenticationSettings();

builder.Services.AddSingleton(authenticationSettings);
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString")));

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddScoped<IUserAggregateService, UserService>();
builder.Services.AddScoped<IUserAggregateRepository, UserRepository>();
builder.Services.AddScoped<IUserAggregateValidator, UserAggregateValidator>();
builder.Services.AddScoped<IEntityValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidatorInput<RegisterDto>, UserValidator>();

builder.Services.AddScoped<ILoginValidator, LoginValidator>();
builder.Services.AddScoped<IEmailValidator, EmailValidator>();
builder.Services.AddScoped<IUserValidator, UserValidator>();
builder.Services.AddScoped<IValidatorId,  ValidatorId>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();