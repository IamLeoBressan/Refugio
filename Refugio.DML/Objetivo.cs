using System;

namespace Refugio.Entities
{
    public class Objetivo: BaseInterface, BaseUser
    {
        public int? Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Usuario { get; set; }

        public bool Ativo
        {
            get
            {
                var dataAtual = DateTime.Now;
                return DataFim > dataAtual && DataInicio <= dataAtual;
            }
        }

        public int DiasAteFim
        {
            get
            {
                return (DataFim - DataInicio).Days;
            }
        }
    }
}
