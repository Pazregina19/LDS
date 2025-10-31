using Microsoft.EntityFrameworkCore;
using TapAndSend.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string not found. Check appsettings.json!");
}

builder.Services.AddDbContext<AppDb>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDb>();
    var clientes = context.Clientes.ToList();
    Console.WriteLine($"Clientes encontrados: {clientes.Count}");
}

app.Run();
