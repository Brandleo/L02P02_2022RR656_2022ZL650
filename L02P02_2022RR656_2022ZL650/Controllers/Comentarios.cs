using L02P02_2022RR656_2022ZL650.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L02P02_2022RR656_2022ZL650.Controllers
{
    public class Comentarios : Controller
    {
        private readonly libreriaDBContext _dbContext;
        public Comentarios(libreriaDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(int idLibro)
        {
            var comentarios = _dbContext.comentarios_libros
                .Where(c => c.id_libro == idLibro)
                .ToList();

            var libro = _dbContext.libros
                .Where(l => l.id == idLibro)
                .Select(l => new
                {
                    l.nombre,
                    AutorNombre = _dbContext.autores
                        .Where(a => a.id == l.id_autor)
                        .Select(a => a.autor)
                        .FirstOrDefault()
                })
                .FirstOrDefault();

            if (libro != null)
            {
                ViewBag.NombreLibro = libro.nombre;
                ViewBag.NombreAutor = libro.AutorNombre ?? "Autor desconocido";
            }
            else
            {
                ViewBag.NombreLibro = "Libro desconocido";
                ViewBag.NombreAutor = "Autor desconocido";
            }

            ViewBag.IdLibro = idLibro;
            return View(comentarios);
        }


        [HttpPost]
        public IActionResult AgregarComentario(int idLibro, string comentario, string usuario)
        {
            if (string.IsNullOrEmpty(comentario) || string.IsNullOrEmpty(usuario))
            {
                ModelState.AddModelError("", "El comentario y el usuario son obligatorios.");
                return RedirectToAction("Index", new { idLibro });
            }

            int nuevoId = (_dbContext.comentarios_libros.Max(c => (int?)c.id) ?? 0) + 1;

            var nuevoComentario = new comentarios_libros
            {
                id = nuevoId,  
                id_libro = idLibro,
                usuario = usuario,
                comentarios = comentario,
                Created_at = DateTime.Now
            };

            _dbContext.comentarios_libros.Add(nuevoComentario);
            _dbContext.SaveChanges();

            return RedirectToAction("Confirmacion");
        }


        public IActionResult Confirmacion()
        {
            var comentario = _dbContext.comentarios_libros
                .OrderByDescending(c => c.Created_at)
                .FirstOrDefault();

            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }


    }
}
