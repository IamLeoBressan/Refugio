using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refugio.WebApi.Models.Input
{
    public class InEvolucao
    {
        public int? Id { get; set; }
        public double Peso { get; set; }
        public DateTime DataMedicao { get; set; }
        public string Observacoes { get; set; }
        public List<InDificuldade> Dificuldades { get; set; }
        public bool EnviarEmail { get; set; }
        public string Email { get; set; }
    }
}
