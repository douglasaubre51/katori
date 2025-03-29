using katori.Data;
using katori.Interfaces;
using katori.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//add services before build
builder.Services.AddControllers();

//ef core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
    options.UseSqlServer(builder.Configuration.GetConnectionString("KatoriDbString"));
});

//add repositories
builder.Services.AddScoped<IJournalRepository, JournalRepository>();

builder.Services.AddScoped<IParticularRepository, ParticularRepository>();

var app = builder.Build();

//call methods to run the services
app.UseHttpsRedirection();

app.MapControllers();

app.Run();