using katori.Data;
using katori.Data.DbActions;
using katori.Interfaces;
using katori.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("Order66", builder =>
    {
        builder.SetIsOriginAllowed(origin =>
        string.IsNullOrEmpty(origin) || origin == "null")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

//add services before build
builder.Services.AddControllers();

//dependency injections
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

//allow cors
app.UseCors("Order66");

//call methods to run the services
//add list of journals to Journals table
if (args.Length == 1 && args[0].ToLower() == "add-journals")
{
    Add.AddJournals(app);
    return;
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();