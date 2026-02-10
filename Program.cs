using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Data;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 🔹 Conexión a PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


try
{
    using var connection = new NpgsqlConnection(connectionString);
    connection.Open();

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("✅ Conexión a PostgreSQL realizada correctamente.");
    Console.ResetColor();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("❌ Error al conectar a PostgreSQL:");
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}
// Servicios básicos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
