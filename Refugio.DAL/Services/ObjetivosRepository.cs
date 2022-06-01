using Microsoft.EntityFrameworkCore;
using Refugio.DAL.DbContexts;
using Refugio.DAL.Services.Interfaces;
using Refugio.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refugio.DAL.Services
{
    public class ObjetivosRepository: GenericRepository, IObjetivosRepository
    {
        private readonly MainContext _mainContext;

        public ObjetivosRepository(MainContext mainContext) : base(mainContext)
        {
            _mainContext = mainContext;
        }

        public async Task<IList<Objetivo>> GetAllObjetivosByUser(string usuario)
        {
            var objetivos = await _mainContext.Objetivos
                        .Where(c => c.Usuario == usuario)
                        .OrderByDescending(e => e.DataFim)
                        .ToListAsync();

            return objetivos.Where(e => e.Ativo).OrderBy(e => e.DataFim)
                .Concat(objetivos.Where(e => !e.Ativo)).ToList();

        }
    }
}
