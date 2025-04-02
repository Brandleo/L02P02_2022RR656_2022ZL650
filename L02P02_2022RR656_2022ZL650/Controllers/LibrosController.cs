using L02P02_2022RR656_2022ZL650.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L02P02_2022RR656_2022ZL650.Controllers
{
    public class LibrosController : Controller
    {
        private readonly libreriaDBContext _libreriaContexto;

        public LibrosController(libreriaDBContext libreriaContexto)
        {
            _libreriaContexto = libreriaContexto;
        }

        public IActionResult LibrosPorAutor(int idAutor)
        {
           
            var autor = _libreriaContexto.autores.FirstOrDefault(a => a.id == idAutor);
            if (autor == null)
            {
                TempData["Error"] = "Autor no encontrado.";
                return RedirectToAction("Index", "Autores"); 
            }

           
            ViewBag.NombreAutor = autor.autor;

            
            var libros = _libreriaContexto.libros
                .Where(l => l.id_autor == idAutor)
                .ToList();

           
            if (!libros.Any())
            {
                TempData["Error"] = "No hay libros de este autor.";
                return RedirectToAction("Index", "Libros");
            }

         
            return View("LibrosPorAutor", libros);
        }

    }
}
