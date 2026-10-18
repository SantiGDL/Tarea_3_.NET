using Microsoft.AspNetCore.Mvc;
using Tarea_3.Interfaz;
using Tarea_3.Models;

namespace Tarea_3
{
    public class LibroController : Controller
    {
        //Incluyo el repositorio de libros
        private readonly ILibroRepository _libroRepository;
        private readonly ILogger<LibroController> _logger;

        public LibroController(ILogger<LibroController> logger, ILibroRepository repositorio)
        {
            _libroRepository = repositorio;
            _logger = logger;

        }
        
        // GET: LibroController/ObtenerLibros
        public ActionResult ListarLibros()
        {
            return View(this._libroRepository.getLibros());
        }

        
        // GET: LibroController/VerDetalle/5
        public ActionResult VerDetalle(string isbn)
        {
            _logger.LogInformation($"Estoy en action VerDetalle, isbn: {isbn}" );
            if (isbn == null)
            {
                return NotFound("Debe especificar ISBN");
            }

            Libro libroBuscado = this._libroRepository.getLibro(isbn);
            if (libroBuscado == null)
            {
                return NotFound($"Libro no encontrado: {isbn}");
            }
            
            return View(libroBuscado);        }

        // GET: LibroController/CrearLibro
        public ActionResult CrearLibro()
        {
            return View();
        }

        // POST: LibroController/CrearLibro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearLibro([Bind("Isbn,Titulo,Autor,FechaPublicacion")] Libro libroNuevo)
        {
            try
            {
                this._libroRepository.crearLibro(libroNuevo);
                
                return RedirectToAction(nameof(ListarLibros));
            }
            catch
            {
                return View();
            }
        }
        

        // GET: LibroController/EditarLibro/5
        public ActionResult EditarLibro(string isbn)
        {
            Libro libroBuscado = this._libroRepository.getLibro(isbn);
            if(libroBuscado == null)
            {
                
                return NotFound("No se encuentra Libro solicitado");
            }
            
            return View(libroBuscado);
        }

        // GET: LibroController/EditarLibro/5
        public ActionResult ConfirmarEditarLibro([Bind("Isbn, Titulo,Autor,FechaPublicacion")] Libro libroEditado)
        {
            try
            {
                this._libroRepository.EditarLibro(libroEditado.Isbn, libroEditado);
                return RedirectToAction(nameof(ListarLibros));
            }
            catch
            {
                return NotFound("No se pudo Editar el Libro solicitado");
            }
        }
        

        // GET: LibroController/EliminarLibro/5
        public ActionResult EliminarLibro(string isbn)
        {
            _logger.LogInformation($"Estoy en ELIMINAR LIBRO, isbn: {isbn}" );

            //Busco si el libro existe antes de eliminarlo
            Libro libroBuscado;
            libroBuscado = this._libroRepository.getLibro(isbn);
            if (libroBuscado == null)
            {
                return NotFound($"ISBN no encontrado: {isbn}");
            }

            //llamo a la vista EliminarLibro.cshtml
            return View(libroBuscado);
        }

        // POST: LibroController/EliminarLibro/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarEliminarLibro(string isbn, IFormCollection collection)
        {
            try
            {
                this._libroRepository.EliminarLibro(isbn);
                //Si funciona lo retorno al mismo lugar por si quiere seguir eliminando
                return RedirectToAction(nameof(ListarLibros));
            }
            catch
            {
                //Si no funciona lo vuelvo dejar en EliminarLibro
                return RedirectToAction(nameof(EliminarLibro));
            }
        }
        
       
        // POST: LibroController/ConfirmarBorrado/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarBorrado(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
    }
}
