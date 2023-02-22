using Webshop.Models;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using Webshop.Controllers;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Default");
//szerintem ez m�g �gy nem j�
builder.Services.AddTransient<ProductServices>();
builder.Services.AddTransient<ProductsController>();

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

//Innen szerintem hi�nyzik a provider

app.Run();
