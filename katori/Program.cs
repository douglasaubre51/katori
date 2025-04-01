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
builder.Services.AddScoped<ILedgerRepository, LedgerRepository>();

var app = builder.Build();

//call methods to run the services
//add list of journals to Journals table
if (args.Length == 1 && args[0].ToLower() == "add")
{
    Add.AddJournals(app);
    return;
}
//retreve data
if (args.Length == 1 && args[0].ToLower() == "ret")
{
    Retrieve.RetrieveLedgers(app);
    return;
}

//allow cors
app.UseCors("Order66");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();