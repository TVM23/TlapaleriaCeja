﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TlapaleriaCeja.AccesoDatos.Data;
using TlapaleriaCeja.AccesoDatos.Repositorio.IRepositorio;

namespace TlapaleriaCeja.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;

        public IBodegaRepositorio Bodega { get; set; }  //AHORA SI SE REQUIERE DE GETTER Y SETTER
        public ICategoriaRepositorio Categoria { get; set; }
        public IMarcaRepositorio Marca { get; set; }
        public IProductoRepositorio Producto { get; set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Bodega = new BodegaRepositorio(_db);
            Categoria = new CategoriaRepositorio(_db);
            Marca = new MarcaRepositorio(_db);
            Producto = new ProductoRepositorio(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
