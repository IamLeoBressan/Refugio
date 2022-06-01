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

        public async Task<IList<Evolucao>> GetAllCompleteByUser(string user)
        {
            return await _mainContext.Evolucoes
                    .Include(e => e.Dificuldades)
                    .Include(e => e.Imagens)
                    .Where(e => e.Usuario == user)
                    .OrderByDescending(e => e.DataMedicao)
                    .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<Evolucao> FindCompleteByUser(string usuario, int Id)
        {
            return await _mainContext.Evolucoes
                    .Include(e => e.Dificuldades)
                    .Include(e => e.Imagens)
                    .FirstOrDefaultAsync(e => e.Id == Id && usuario == e.Usuario);                
        }

        public async Task<bool> ExisteEvolucaoNaData(string user, DateTime data)
        {
            return await _mainContext.Evolucoes.AnyAsync(e => e.Usuario == user && e.DataMedicao == data);
        }
    }
}
