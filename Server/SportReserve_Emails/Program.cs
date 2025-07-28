using SportReserve_Emails;
using SportReserve_Emails.Services;
using SportReserve_Shared.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var emailAuthentication = new EmailAuthentication();

builder.Configuration.GetSection("EmailAuthentication").Bind(emailAuthentication);
builder.Services.AddSingleton(emailAuthentication);

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

var emailEventHandler = new EmailEventHandler(emailAuthentication);

var consumer = new EmailConsumer(emailEventHandler);

consumer.ConsumeUserRegisteredEvent();

app.Run();
