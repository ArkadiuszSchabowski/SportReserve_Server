using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Interfaces.Base;
using SportReserve_Shared.Middleware;
using SportReserve_Shared.Models.User;
using SportReserve_Users;
using SportReserve_Users.CompositionRoot;
using SportReserve_Users.Interfaces;
using SportReserve_Users.Interfaces.Aggregates;
using SportReserve_Users.RabbitMq;
using SportReserve_Users.Repositories;
using SportReserve_Users.Seeders;
using SportReserve_Users.Services;
using SportReserve_Users.Validators;
using SportReserve_Users_Db;
using SportReserve_Users_Db.Entities;
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("UserPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
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

builder.Services.AddDbContext<UserDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString")));

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
builder.Services.AddScoped<IValidatorId, ValidatorId>();

builder.Services.AddScoped<RoleSeeder>();
builder.Services.AddScoped<UserSeeder>();
builder.Services.AddScoped<IProducerUser, ProducerUser>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors("UserPolicy");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<UserDbContext>();
    context.Database.Migrate();

    var roleSeeder = services.GetRequiredService<RoleSeeder>();
    roleSeeder.SeedData();

    var userSeeder = services.GetRequiredService<UserSeeder>();
    userSeeder.SeedData();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();