using Microsoft.EntityFrameworkCore;
using NaTour2021_API.DBHelper;
using NaTour2021_API.Repositories.PointOfInterest;
using NaTour2021_API.Repositories.Track;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PostgreSqlHelper>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("NaTour2021DB")));
builder.Services.AddScoped<ITrackRepository, PostgreTrackRepository>();
builder.Services.AddScoped<IPointOfInterestRepository, PostgrePOIRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
