﻿using Administrador.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administrador.Dominio
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string nombre { get; set; }

    }
}
