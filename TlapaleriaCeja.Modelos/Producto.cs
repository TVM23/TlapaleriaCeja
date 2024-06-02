using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlapaleriaCeja.Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es requerido")]
        [MaxLength(60, ErrorMessage = "Máximo 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El SKU es requerido")]
        [MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public string SKU { get; set; }


        [MaxLength(30, ErrorMessage = "Máximo 30 caracteres")]
        public string NumeroSerie { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a cero")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "El costo es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser mayor o igual a cero")]
        public double Costo { get; set; }
        
        public string ImagenUrl { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public bool Estado { get; set; }

        //Hagamos la relación con la tabla categoría
        [Required(ErrorMessage = "La categoría es requerida")]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        //Hagamos la relacion con la tabla marca
        [Required(ErrorMessage = "La marca es requerida")]
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }

        //Hagamos la recursividad del padre
        public int? PadreId { get; set; }  //El ? señala que el valor puede ser nulo y no se convierta en 0
        public virtual Producto Padre { get; set; }  //El virtual hace que se pueda usar la misma clase


    }
}