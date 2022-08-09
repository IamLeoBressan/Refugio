using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.Entities
{
    public class Imagem: BaseInterface
    {
        public int? Id { get; set; }
        public int EvolucaoId { get; set; }
        
        public Evolucao Evolucao { get; set; }
        public string Nome { get; set; }
        public byte[] BytesImagem { get; set; }
    }
}
