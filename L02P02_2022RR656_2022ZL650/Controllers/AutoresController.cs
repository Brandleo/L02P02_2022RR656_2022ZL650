using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using L02P02_2022RR656_2022ZL650.Models;

namespace L02P02_2022RR656_2022ZL650.Controllers
{
    public class AutoresController : Controller
    {
        public readonly libreriaDBContext _libreriaContexto;


        public AutoresController(libreriaDBContext libreriaContexto)

        {
            _libreriaContexto = libreriaContexto;
        }

        /* public IActionResult Index()
         {
             var listaAutores = _libreriaContexto.autores.ToList();
             return View(listaAutores);

         }
         */

        public IActionResult Index()
        {
            var listaAutores = (from a in _libreriaContexto.autores select a).ToList();


            ViewData["listadoAutores"] = listaAutores;


            return View();
        }


    }
}
