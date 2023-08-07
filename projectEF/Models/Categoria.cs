using System.ComponentModel.DataAnnotations;

namespace projectEF.Models;

public class Categoria
{
    //[Key]
    public Guid CategoriaId { get; set; }
    //[Required]
    //[MaxLength(100)]
    public string Nombre { get; set; }
    public string Descripcion { get; set;}
    public int Peso { get; set;}
    public virtual ICollection<Tarea> Tareas { get; set; }
}