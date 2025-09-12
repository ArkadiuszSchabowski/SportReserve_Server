using Microsoft.IdentityModel.Tokens;
using SportReserve_ApiGateway.Helpers;
using SportReserve_ApiGateway.Validators;
using SportReserve_Reservations;
using SportReserve_Reservations.DataAccess;
using SportReserve_Reservations.Interfaces;
using SportReserve_Reservations.Services;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Middleware;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
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

builder.Services.AddScoped<IReservationAccess, ReservationAccess>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddScoped<IHttpResponseValidator, HttpResponseValidator>();
builder.Services.AddScoped<IHttpResponseHelper, HttpResponseHelper>();

builder.Services.AddHttpClient("UserService", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001/api/user/");
});

builder.Services.AddHttpClient("RaceService", client =>
{
    client.BaseAddress = new Uri("https://localhost:5002/api/race/");
});

builder.Services.AddHttpClient("RaceTraceService", client =>
{
    client.BaseAddress = new Uri("https://localhost:5002/api/racetrace/");
});

builder.Services.AddScoped<ErrorHandlingMiddleware>();

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
