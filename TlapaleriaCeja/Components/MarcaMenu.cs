using Microsoft.AspNetCore.Mvc;
using TlapaleriaCeja.AccesoDatos.Repositorio.IRepositorio;
using TlapaleriaCeja.Modelos;

namespace TlapaleriaCeja.Components
{
    public class MarcaMenu : ViewComponent
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public MarcaMenu(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Marca> marcaLista = await _unidadTrabajo.Marca.ObtenerTodos();
            return View(marcaLista);
        }

    }
}
