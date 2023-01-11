using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using OnionSolution.Core.Application;
using OnionSolution.Infraestructure.EF.Persistence;
using OnionSolution.Infraestructure.Shared;
using OnionSolution.Presentation.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureHostOptions(
    o =>
    {
        //o.ShutdownTimeout = TimeSpan.FromSeconds(30);
    });

// Add services to the container.

builder.Services.AddApplicationLayer();
builder.Services.AddSharedInfraestructure(builder.Configuration);
builder.Services.AddPersistenceInfraestructure(builder.Configuration);
// API versioning
builder.Services.AddApiVersioningExtension();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseErrorHandlingMiddleware();

app.MapControllers();

app.Run();
