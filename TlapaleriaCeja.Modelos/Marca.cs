﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlapaleriaCeja.Modelos
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [MaxLength(60, ErrorMessage = "El nombre solo se compone de 60 caracteres como máximo")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [MaxLength(100, ErrorMessage = "La descripción solo se compone de 100 caracteres como máximo")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El estado de la marca es requerido")]
        public bool Estado { get; set; }
    }
}
