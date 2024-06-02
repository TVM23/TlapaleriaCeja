using Microsoft.AspNetCore.Mvc;
using TlapaleriaCeja.AccesoDatos.Repositorio.IRepositorio;

namespace TlapaleriaCeja.Areas.Inventario.Controllers
{
    [Area("Inventario")]
    public class ProductoCatalogoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public ProductoCatalogoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult ProductoCatalogo()
        {
            return View();
        }
    }
}
