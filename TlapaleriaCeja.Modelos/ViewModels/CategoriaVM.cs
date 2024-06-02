using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlapaleriaCeja.Modelos.ViewModels
{
    public class CategoriaVM
    {
        public Categoria Categoria { get; set; }
        public IViewComponentResult CategoriaMenu { get; set; }
    }
}
