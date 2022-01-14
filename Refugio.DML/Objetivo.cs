using System;

namespace Refugio.Entities
{
    public class Objetivo: BaseInterface
    {
        public int? Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Usuario { get; set; }

        public int DiasAteFim()
        {
            return (DataFim - DataInicio).Days;
        }
    }
}
