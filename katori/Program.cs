using katori.Data;
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

var app = builder.Build();

//call methods to run the services
app.UseHttpsRedirection();

app.MapControllers();

app.Run();