using BlazorCrud.Server;
using BlazorCrud.Server.Models;
using BlazorCrud.Server.Repositorio.MetodoAplicado.Implementacion;
using BlazorCrud.Server.Repositorio.MetodoAplicado.Interfaces;
using BlazorCrud.Server.Repositorio.MetodoGenerico.Implementacion;
using BlazorCrud.Server.Repositorio.MetodoGenerico.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddDbContext<NominasDbContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("QuerySql")));

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddAutoMapper(typeof(MappingConfig));

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

builder.Services.AddTransient(typeof(IMetodoGenerico<>), typeof(MetodoGenerico<>));
builder.Services.AddTransient(typeof(IMetodoLookupGenerico<>), typeof(MetodoLookupGenerico<>));
builder.Services.AddScoped<IMetodoPersonal, MetodoPersonal>();
builder.Services.AddScoped<IMetodoRangoPersonal, MetodoRangoPersonal>();

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|
//activacion de cores

builder.Services.AddCors(opciones => 
{
    opciones.AddPolicy("nuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
    });
});

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|
//espacio de activacion de servicios

app.UseCors("nuevaPolitica");

//_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-|

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
