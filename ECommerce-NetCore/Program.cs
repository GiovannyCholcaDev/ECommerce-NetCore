using ECommerce_NetCore.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<ECommerceNetCoreDbContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=ECommerceData;Integrated Security=True;TrustServerCertificate=True");
    options.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();
});



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