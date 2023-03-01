using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using VSporte.Core;
using VSporte.Core.Abstract;
using VSporteAPI.Data;
using VSporteAPI.Data.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connstr = builder.Configuration.GetConnectionString("Postgres");

builder.Services.AddDbContext<VSporteAPIDbContext>(o => o.UseNpgsql(connstr));
builder.Services.AddTransient<IPlayerService, PlayerService>();
builder.Services.AddTransient<IPlayerRepository, PlayerRepository>();
builder.Services.AddTransient<IClubService, ClubService>();
builder.Services.AddTransient<IClubRepository, ClubRepository>();
builder.Services.AddTransient<IMatchEventService, MatchEventService>();
builder.Services.AddTransient<IMatchEventRepository, MatchEventRepository>();
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
