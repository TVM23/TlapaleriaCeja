using TlapaleriaCeja.AccesoDatos.Repositorio.IRepositorio;
using TlapaleriaCeja.Modelos;
using TlapaleriaCeja.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace TlapaleriaCeja.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoriaController(IUnidadTrabajo unidadTrabajo, IWebHostEnvironment webHostEnvironment)
        {
            _unidadTrabajo = unidadTrabajo;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Metodo Upsert GET
        public async Task<IActionResult> Upsert(int? id)
        {
            Categoria categoria = new Categoria();
            if (id == null)
            {
                //creamos un nuevo registro
                categoria.Estado = true;
                return View(categoria);
            }
            categoria = await _unidadTrabajo.Categoria.Obtener(id.GetValueOrDefault());
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        #region API
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = _webHostEnvironment.WebRootPath; //Trae direccion del sitio
                if (categoria.Id == 0)
                {
                    //crear nuevo producto
                    string upload = webRootPath + Ds.CategoriaImagenRuta;
                    //Crear un id unico en mi sistema
                    string fileName = Guid.NewGuid().ToString();
                    //creamos nueva variable para conocer la extension del archivo
                    Console.Write(1);
                    Console.Write(files);
                    string extension = Path.GetExtension(files[0].FileName);

                    //habilitar el filestream para crear el archivo de imagen en tiemo real
                    using (var filestream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    categoria.ImagenUrl = fileName + extension;
                    await _unidadTrabajo.Categoria.Agregar(categoria);
                }
                else
                {
                    //Actualizar el producto
                    var objCategoria = await _unidadTrabajo.Categoria.ObtenerPrimero(p => p.Id == categoria.Id, isTracking: false);
                    if (files.Count > 0)
                    {
                        string upload = webRootPath + Ds.CategoriaImagenRuta;
                        string fileName = Guid.NewGuid().ToString();
                        string extension = Path.GetExtension(files[0].FileName);

                        //borrar la imagen anterior
                        var anteriorfile = Path.Combine(upload, objCategoria.ImagenUrl);
                        //verificar que la imagen exista
                        if (System.IO.File.Exists(anteriorfile))
                        {
                            System.IO.File.Delete(anteriorfile);
                        }
                        //Creamos la nueva imagen
                        using (var filestream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                        {
                            files[0].CopyTo(filestream);
                        }
                        categoria.ImagenUrl = fileName + extension;
                    }// si no eligen imagen
                    else
                    {
                        categoria.ImagenUrl = objCategoria.ImagenUrl;
                    }
                    _unidadTrabajo.Categoria.Actualizar(categoria);
                }
                TempData[Ds.Exitosa] = "Categoría Registrada";
                await _unidadTrabajo.Guardar();
                return View("Index");
            }
            TempData[Ds.Error] = "Error al guardar el producto";
            return View(categoria);
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Categoria.ObtenerTodos();

            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                        == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                        == nombre.ToLower().Trim() && b.Id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Categoria.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var categoriaDB = await _unidadTrabajo.Categoria.Obtener(id);
            if (categoriaDB == null)
            {
                return Json(new { success = false, message = "Error al borrar el registro en la base de datos" });
            }
            //borrar la imagen del producto eliminado
            string upload = _webHostEnvironment.WebRootPath + Ds.CategoriaImagenRuta;
            var anteriorFile = Path.Combine(upload, categoriaDB.ImagenUrl);
            if (System.IO.File.Exists(anteriorFile))
            {
                System.IO.File.Delete(anteriorFile);
            }
            _unidadTrabajo.Categoria.Remover(categoriaDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Categoria eliminada con éxito" });

        }
        #endregion
    }
}
