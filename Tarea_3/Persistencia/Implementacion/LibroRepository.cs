using Tarea_3.Models;

namespace Tarea_3.Interfaz.Implementacion;

public class LibroRepository : ILibroRepository
{
    //Inicializo la lista vacía
    private IDictionary<String, Libro> _listaLibros = new Dictionary<string, Libro>();

    public LibroRepository()
    {
        Libro l1 = new Libro("BB1A", "Libro 1", "Santiago G", new DateOnly(2002,10,25));
        Libro l2 = new Libro("AACB", "Libro 2", "Santiago G", new DateOnly(2008,4,24));
        Libro l3 = new Libro("113S", "Libro 3", "Santiago G", new DateOnly(2012,4,22));
        
        _listaLibros.Add(l1.Isbn, l1);
        _listaLibros.Add(l2.Isbn, l2);
        _listaLibros.Add(l3.Isbn, l3);
    }

    public void crearLibro(Libro libroNuevo)
    {
        _listaLibros.Add(libroNuevo.Isbn, libroNuevo);
    }

    public Libro getLibro(string isbn)
    {
        Libro respuesta;
        //Busco el libro en el diccionario
        _listaLibros.TryGetValue(isbn, out respuesta);
        return respuesta;
        
    }

    public List<Libro> getLibros()
    {
        return _listaLibros.Values.ToList();
    }

    public void EliminarLibro(string isbn)
    {
        this._listaLibros.Remove(isbn);
    }

    public bool EditarLibro(string isbn, Libro libroEditado)
    {
        if (!_listaLibros.ContainsKey(isbn))
        {
            return false;
        }

        _listaLibros[isbn] = libroEditado;
        return true;
    }
}