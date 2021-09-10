using Microsoft.AspNetCore.Identity;

namespace Refugio.Seguranca
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
