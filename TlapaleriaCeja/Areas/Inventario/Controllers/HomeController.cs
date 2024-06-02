using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TlapaleriaCeja.AccesoDatos.Repositorio.IRepositorio;
using TlapaleriaCeja.Modelos;
using TlapaleriaCeja.Modelos.ViewModels;

namespace TlapaleriaCeja.Areas.Inventario.Controllers
{
    [Area("Inventario")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnidadTrabajo _unidadTrabajo;

        public HomeController(ILogger<HomeController> logger, IUnidadTrabajo unidadTrabajo)
        {
            _logger = logger;
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Categorias"] = await _unidadTrabajo.Categoria.ObtenerTodos();
            ViewData["Productos"] = await _unidadTrabajo.Producto.ObtenerTodos();
            ViewData["Marcas"] = await _unidadTrabajo.Marca.ObtenerTodos();
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
