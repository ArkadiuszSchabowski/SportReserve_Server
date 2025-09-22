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

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<ISenderFactory, SenderFactory>();
builder.Services.AddScoped<EmailConsumer>();

builder.Services.AddSingleton<EmailAuthentication>(sp =>
{
    var emailAuthentication = new EmailAuthentication();
    builder.Configuration.GetSection("EmailAuthentication").Bind(emailAuthentication);
    return emailAuthentication;
});

builder.Services.AddSingleton<IEmailAuthentication>(sp =>
    sp.GetRequiredService<EmailAuthentication>());

builder.Services.AddScoped<ErrorHandlingMiddleware>();

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

using (var scope = app.Services.CreateScope())
{
    var consumer = scope.ServiceProvider.GetRequiredService<EmailConsumer>();
    consumer.ConsumeUserRegisteredEvent();
}

app.Run();
