using System.ComponentModel.DataAnnotations;

namespace Tarea_3.Models;

public class Libro
{
    public string Isbn { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public DateOnly FechaPublicacion { get; set; }

    public Libro(string isbn, string titulo, string autor, DateOnly fechaPublicacion)
    {
        this.Isbn = isbn;
        this.Titulo = titulo;
        this.Autor = autor;
        this.FechaPublicacion = fechaPublicacion;
    }
    
    public Libro()
    {
    }

}