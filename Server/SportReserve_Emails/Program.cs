using SportReserve_Emails;
using SportReserve_Emails.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var emailEventHandler = new EmailEventHandler();

var consumer = new EmailConsumer(emailEventHandler);

consumer.ConsumeUserRegisteredEvent();

app.Run();
