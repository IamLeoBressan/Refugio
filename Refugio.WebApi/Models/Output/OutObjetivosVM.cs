using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refugio.WebApi.Models.Input
{
    public class OutObjetivosVM
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Usuario { get; set; }
    }
}
