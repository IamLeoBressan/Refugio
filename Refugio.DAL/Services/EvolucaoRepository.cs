using Refugio.DAL.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.DAL.Services
{
    public class EvolucaoRepository : GenericRepository
    {
        public EvolucaoRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
