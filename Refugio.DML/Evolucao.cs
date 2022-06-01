using System;
using System.Collections.Generic;

namespace Refugio.Entities
{
    public class Evolucao : BaseInterface, BaseUser
    {
        public int? Id { get; set; }
        public double Peso { get; set; }
        public DateTime DataMedicao { get; set; }
        public string Observacoes { get; set; }
        public List<Dificuldade> Dificuldades { get; set; }
        public bool EnviarEmail { get; set; }
        public string Email { get; set; }
        public List<Imagem> Imagens { get; set; } = new List<Imagem>();
        public string Usuario { get; set; }
    }
}
