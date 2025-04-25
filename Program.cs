using ecommerce.Aplicacion.Handlers;
using ecommerce.Domain.Factories;
using ecommerce.Domain.Interfaces;
using ecommerce.Infrastructure.Persistence;
using ecommerce.Infrastructure.Repositories;
using ecommerce.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MediatR;
using System.Reflection;
using ecommerce.Infrastructure.Cache;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios necesarios para Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = " API de ecommerce/retail",
        Version = "v1"
    });
});

// Agregar servicios al contenedor de dependencias
builder.Services.AddControllers();

// Registrar AutoMapper
builder.Services.AddAutoMapper(typeof(Program));  // Registrar el perfil de AutoMapper

// Registrar MediatR para manejar los eventos y commands
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// habilita el servicio de memoria
builder.Services.AddMemoryCache();
builder.Services.AddScoped<ICacheService, MemoryCacheService>();

// Registrar las dependencias necesarias
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrdenCompraRepository, OrdenCompraRepository>();

// Registrar la Factory
builder.Services.AddScoped<OrdenCompraFactory>();


// Configuración de DbContext con InMemoryDatabase
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("EcommerceDb"));

builder.Services.AddScoped<ICacheService, MemoryCacheService>();

var app = builder.Build();

// Configura Swagger UI en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Ecommerce V1");
    });
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();