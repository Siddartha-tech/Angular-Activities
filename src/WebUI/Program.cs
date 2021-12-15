// using System.Reflection;
using Application;
using Application.Activities.Commands.CreateActivity;
using Application.Common.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure;
// using Infrastructure.Persistence;
// using Microsoft.OpenApi.Models;
using WebUI.Filters;
using WebUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.pro
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false); //&& 
                                                                                 // x.RegisterValidatorsFromAssemblyContaining<CreateActivityCommandValidator>());
builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddHttpContextAccessor();
// builder.Services.AddOpenApiDocument(configure =>
//         {
//             configure.Title = "CleanArchitectureDemo API";
//             configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
//             {
//                 Type = OpenApiSecuritySchemeType.ApiKey,
//                 Name = "Authorization",
//                 In = OpenApiSecurityApiKeyLocation.Header,
//                 Description = "Type into the textbox: Bearer {your JWT token}."
//             });

//             configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
//         });
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