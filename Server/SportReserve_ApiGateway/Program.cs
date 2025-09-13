using SportReserve_ApiGateway.Helpers;
using SportReserve_ApiGateway.Validators;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Middleware;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

builder.Services.AddHttpClient("EmailService", client =>
{
    client.BaseAddress = new Uri("https://localhost:5003/api/email/");
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("ApiGatewayPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IHttpResponseValidator, HttpResponseValidator>();
builder.Services.AddScoped<IHttpResponseHelper, HttpResponseHelper>();

builder.Services.AddScoped<ErrorHandlingMiddleware>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseCors("ApiGatewayPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
