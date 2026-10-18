using Tarea_3.Models;

namespace Tarea_3.Interfaz;

public interface ILibroRepository
{
    public void crearLibro(Libro libroNuevo);
    
    public Libro getLibro(string isbn);

    public List<Libro> getLibros();

    public void EliminarLibro(string isbn);

    public bool EditarLibro(string isbn, Libro libroEditado);
}