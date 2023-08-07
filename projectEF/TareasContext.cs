using Microsoft.EntityFrameworkCore;
using projectEF.Models;


namespace projectEF;

public class TareasContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    public TareasContext(DbContextOptions<TareasContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categorias = new List<Categoria>();
        categorias.Add(new Categoria(){CategoriaId = Guid.Parse("71c3ac95-768d-4d95-bff8-e523f2a37201"), Nombre = "Tareas Personbales",Peso = 20, });
        categorias.Add(new Categoria(){CategoriaId = Guid.Parse("71c3ac95-768d-4d95-bff8-e523f2a37202"), Nombre = "Tareas Laborales",Peso = 20, });

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(c => c.CategoriaId);
            categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(c => c.Descripcion).IsRequired(false);
            categoria.Property(c => c.Peso);
            categoria.HasData(categorias);
        });

        List<Tarea> tareas = new List<Tarea>();
        tareas.Add(new Tarea(){TareId = Guid.Parse("71c3ac95-768d-4d95-bff8-e523f2a37210"),CategoriaId = Guid.Parse("71c3ac95-768d-4d95-bff8-e523f2a37201"),Titulo = "Ir GYM", PrioridadTarea = Prioridad.Baja,FechaCreacion = DateTime.Now});
        tareas.Add(new Tarea(){TareId = Guid.Parse("71c3ac95-768d-4d95-bff8-e523f2a37211"),CategoriaId = Guid.Parse("71c3ac95-768d-4d95-bff8-e523f2a37202"),Titulo = "Presentar API", PrioridadTarea = Prioridad.Alta,FechaCreacion = DateTime.Now});

        /*Constructor de Modelos:
           1. indica que es una tabla
           2. indica que es una calve primaria
           3. indica que es hay una categoria para muchas tareas
           4. indica que es un campo obligatorio y que tiene un maximo de 200 caracteres
           5-7 indica que es un campo no obligatorio
           8. indica que ignore ese campo
        */
        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");                                             
            tarea.HasKey(t => t.TareId);                                   
            tarea.HasOne(t => t.Categoria).WithMany(c => c.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);  
            tarea.Property(t => t.Descripcion).IsRequired(false);                            
            tarea.Property(t => t.PrioridadTarea);                        
            tarea.Property(t => t.FechaCreacion);                          
            tarea.Ignore(t => t.resumen);
            tarea.HasData(tareas);

        });
    }

    
    
} 