using System.Reflection;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.pro
builder.Services.AddInfrastructure(builder.Configuration);
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
//Seed data
if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    await app.UseDataSeed();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();