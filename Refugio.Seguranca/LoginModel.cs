using System.ComponentModel.DataAnnotations;

namespace Refugio.Seguranca
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
