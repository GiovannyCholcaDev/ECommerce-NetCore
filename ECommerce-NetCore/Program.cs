using ECommerce_NetCore.DataAccess;
using ECommerce_NetCore.DataAccess.repositories;
using ECommerce_NetCore.Entities;
using ECommerce_NetCore.Services.Implementations;
using ECommerce_NetCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();


builder.Services.AddDbContext<ECommerceNetCoreDbContext>(options =>
{
    options.UseSqlServer("Server=localhost,1434;Database=ECommerceData;User Id=sa;Password=Polyglot#3000;TrustServerCertificate=True");
    options.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<List<Category>>(new List<Category>());


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
