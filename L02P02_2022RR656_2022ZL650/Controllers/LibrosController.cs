using L02P02_2022RR656_2022ZL650.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2022RR656_2022ZL650.Controllers
{
    public class LibrosController : Controller
    {
        private readonly libreriaDBContext _libreriaContexto;

        public LibrosController(libreriaDBContext libreriaContexto)
        {
            _libreriaContexto = libreriaContexto;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
