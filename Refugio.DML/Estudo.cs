using System;
using System.ComponentModel.DataAnnotations;

namespace Refugio.Entities
{
    public class Estudo
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Categoria { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [Required]
        public DateTime DataConclusao { get; set; }
    }
}
