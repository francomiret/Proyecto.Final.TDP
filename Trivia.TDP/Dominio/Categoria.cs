﻿using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {

        public int CategoriaId { get; set; }
        public string nombre { get; set; }

        public int providedId { get; set; }

    }
}
