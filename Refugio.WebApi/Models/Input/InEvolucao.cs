using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Refugio.WebApi.Models.Input
{
    public class InEvolucao
    {
        public int? Id { get; set; }
        [Required]
        public double Peso { get; set; }
        [Required]
        public DateTime DataMedicao { get; set; }
        public string Observacoes { get; set; }
        public List<InDificuldade> Dificuldades { get; set; }
        [Required]
        public bool EnviarEmail { get; set; }
        public string Email { get; set; }

        public List<InImagem> FilesImg { get; set; }

        public List<IFormFile> Files { get; set; }
    }
}
