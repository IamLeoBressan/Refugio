using Microsoft.AspNetCore.Http;

namespace Refugio.WebApi.Models.Input
{
    public class InImagem
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }

    }
}
