using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;
using DbContext = System.Data.Entity.DbContext;


var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareasContext>(p 
  //  => p.UseInMemoryDatabase("tareasDB"));

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));



var app = builder.Build();
app.MapGet("/", () => "Hola Mundo");
app.MapGet("/dbConexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok($"base de datos en memoria: {dbContext.Database.IsInMemory()}");
});

app.Run();  