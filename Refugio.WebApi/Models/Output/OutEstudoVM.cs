using System;

namespace Refugio.WebApi.Models
{

    public class OutEstudoVM
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
