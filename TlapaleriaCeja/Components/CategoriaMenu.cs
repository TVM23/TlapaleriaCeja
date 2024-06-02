using Microsoft.AspNetCore.Mvc;
using TlapaleriaCeja.AccesoDatos.Repositorio.IRepositorio;
using TlapaleriaCeja.Modelos;
using TlapaleriaCeja.Utilidades;

namespace TlapaleriaCeja.Components
{
    public class CategoriaMenu : ViewComponent
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        public CategoriaMenu(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Categoria> categoriaLista = await _unidadTrabajo.Categoria.ObtenerTodos();
            return View(categoriaLista);
        }

    }
}
