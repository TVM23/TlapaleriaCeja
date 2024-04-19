using Microsoft.AspNetCore.Mvc;
using TlapaleriaCeja.AccesoDatos.Repositorio.IRepositorio;

namespace TlapaleriaCeja.Areas.Inventario.Controllers
{
    [Area("Inventario")]
    public class ProductoDetalleController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public ProductoDetalleController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult ProductoDetalle()
        {
            return View();
        }
        public IActionResult Contacto()
        {
            return View();
        }
    }
}
