using SportReserve_Emails;
using SportReserve_Emails.Infrastructure;
using SportReserve_Emails.Interfaces;
using SportReserve_Emails.Services;
using SportReserve_Shared.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("EmailPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var emailAuthentication = new EmailAuthentication();

var senderFactory = new SenderFactory(emailAuthentication);

builder.Configuration.GetSection("EmailAuthentication").Bind(emailAuthentication);
builder.Services.AddSingleton(emailAuthentication);

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISenderFactory, SenderFactory>();

var app = builder.Build();

app.UseCors("EmailPolicy");

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var emailEventHandler = new EmailEventHandler(emailAuthentication, senderFactory);

var consumer = new EmailConsumer(emailEventHandler);

consumer.ConsumeUserRegisteredEvent();

app.Run();
