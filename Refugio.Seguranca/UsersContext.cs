using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Refugio.Seguranca
{
    public class UsersContexto : IdentityDbContext<Usuario>
    {
        public UsersContexto(DbContextOptions<UsersContexto> options) : base(options)
        {

        }
    }
}
