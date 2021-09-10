using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.Entities
{
    public class Dificuldade
    {
        public int? Id { get; set; }
        public string Descricao { get; set; }
        public int EvolucaoId { get; set; }
        public Evolucao Evolucao { get; set; }
    }
}
