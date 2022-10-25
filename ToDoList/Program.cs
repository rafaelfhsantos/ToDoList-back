using Microsoft.EntityFrameworkCore;
using System;
using ToDoList.ApiEndpoints;
using ToDoList.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration
                       .GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
                 options
                 .UseMySql(connectionString,
                 ServerVersion.AutoDetect(connectionString)));

builder.Services.AddCors();

var app = builder.Build();

app.MapToDosEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(p =>
{
    p.AllowAnyOrigin();
    p.AllowAnyMethod();
    p.AllowAnyHeader();
});

app.Run();

