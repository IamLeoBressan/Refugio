using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Refugio.WebApi.Models.Input
{
    public class InObjetivosVM
    {
        public int? Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Usuario { get; set; }
    }
}
