﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Refugio.WebApi.Models
{
    
    public class InEstudoVM
    {
        public Guid Id { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
    }
}