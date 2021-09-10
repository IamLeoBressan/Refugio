using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.Entities
{
    public class Evolucao : BaseInterface
    {
        public int? Id { get; set; }
        public double Peso { get; set; }
        public DateTime DataMedicao { get; set; }
        public string Observacoes { get; set; }
        public List<Dificuldade> Dificuldades { get; set; }
        public bool EnviarEmail { get; set; }
        public string Email { get; set; }
    }
}
