using Microsoft.EntityFrameworkCore;
using SportReserve_Races.CompositionRoot;
using SportReserve_Races.Interfaces;
using SportReserve_Races.Interfaces.Aggregates;
using SportReserve_Races.Repositories;
using SportReserve_Races.Seeders;
using SportReserve_Races.Services;
using SportReserve_Races.Validators;
using SportReserve_Races_Db;
using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Interfaces.Base;
using SportReserve_Shared.Middleware;
using SportReserve_Shared.Models.Race;
using SportReserveServer.Interfaces;
using SportReserveServer.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("RacePolicy", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<RaceDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnectionString")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddScoped<IRaceAggregateService, RaceService>();
builder.Services.AddScoped<IRaceTraceAggregateService, RaceTraceService>();

builder.Services.AddScoped<IRaceAggregateRepository, RaceRepository>();
builder.Services.AddScoped<IRepository<RaceTrace>, RaceTraceRepository>();

builder.Services.AddScoped<IRaceAggregateValidator, RaceAggregateValidator>();
builder.Services.AddScoped<IRaceTraceAggregateValidator, RaceTraceAggregateValidator>();

builder.Services.AddScoped<IRaceTraceValidator, RaceTraceValidator>();
builder.Services.AddScoped<IRaceValidator, RaceValidator>();

builder.Services.AddScoped<IEntityValidator<Race>, RaceValidator>();
builder.Services.AddScoped<IEntityNullValidator<RaceTrace>, RaceTraceValidator>();

builder.Services.AddScoped<IValidatorInput<AddRaceDto>, RaceValidator>();
builder.Services.AddScoped<IValidatorInput<AddRaceTraceDto>, RaceTraceValidator>();

builder.Services.AddScoped<IValidatorId, ValidatorId>();

builder.Services.AddScoped<IRaceSeeder, RaceSeeder>();

var app = builder.Build();

app.UseCors("RacePolicy");

app.UseMiddleware<ErrorHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<RaceDbContext>();
    context.Database.Migrate();

    var raceSeeder = services.GetRequiredService<IRaceSeeder>();

    raceSeeder.SeedData();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
