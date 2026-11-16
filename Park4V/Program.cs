using Microsoft.EntityFrameworkCore;
using Park4VMariaSolucion.Data;
using Park4VMariaSolucion.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Añadir el dbcontext

builder.Services.AddDbContext<Park4VContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Park4VConnection")));
// Añadir los repositorios
builder.Services.AddScoped<RepositorioCiudades>();
builder.Services.AddScoped<RepositorioZonas>();
builder.Services.AddScoped<RepositorioClientes>();


// Activar la serialización de ciclos de referencia para evitar errores al serializar entidades con relaciones circulares
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // 1. Expone el endpoint del documento OpenAPI nativo (ej: /openapi/v1.json)
    app.MapOpenApi();

    // Si instalaste Swashbuckle para seguir usando Swagger UI:
    app.UseSwaggerUI(options =>
    {
        // Le indicamos dónde está el archivo JSON generado por .NET
        options.SwaggerEndpoint("/openapi/v1.json", "API REST Park4V v1");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
