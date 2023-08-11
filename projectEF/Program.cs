using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;
using projectEF.Models;
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


app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(c=>c.Categoria));
});

//Obtener datos medinate Id
/*app.MapGet("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, Guid id) =>
{
    return Results.Ok(dbContext.Tareas.Include(c=>c.Categoria));
});*/

app.MapPost("/api/Tareas", async([FromServices] TareasContext dbContext, [FromBody ] Tarea tarea) =>
{
    tarea.TareId = new Guid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok();

});


app.MapPut("/api/Tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    var ActualizarTareas = dbContext.Tareas.Find(id);
    if (ActualizarTareas != null)
    {
        ActualizarTareas.CategoriaId = tarea.CategoriaId;
        ActualizarTareas.Titulo = tarea.Titulo;
        ActualizarTareas.PrioridadTarea = tarea.PrioridadTarea;
        ActualizarTareas.Descripcion = tarea.Descripcion;
        ActualizarTareas.FechaCreacion = tarea.FechaCreacion;

        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

app.MapDelete("/api/Tareas/{id}",
    async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) =>
    {
        var BuscarTarea = dbContext.Tareas.Find(id);
        if (BuscarTarea != null)
        {
            dbContext.Remove(BuscarTarea);
            await dbContext.SaveChangesAsync();
            return Results.Ok();
        }
        return Results.NotFound();
    });

app.Run();  