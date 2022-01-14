using Microsoft.EntityFrameworkCore;
using Refugio.DAL.DbContexts;
using Refugio.DAL.Services.Interfaces;
using Refugio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.DAL.Services
{
    public class EvolucaoRepository : GenericRepository, IEvolucaoRepository
    {
        private readonly MainContext _mainContext;

        public EvolucaoRepository(MainContext mainContext) : base(mainContext)
        {
            this._mainContext = mainContext;
        }

        public async Task<IList<Evolucao>> GetAllComplete()
        {
            return await _mainContext.Evolucoes
                    .Include(e => e.Dificuldades)
                    .OrderByDescending(e => e.DataMedicao)
                    .AsNoTracking()
                    .ToListAsync();
        }

    }
}
