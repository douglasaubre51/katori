var builder = WebApplication.CreateBuilder(args);

//add services before build
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

//call methods to run the services
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();