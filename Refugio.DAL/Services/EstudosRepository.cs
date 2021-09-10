using Microsoft.EntityFrameworkCore;
using Refugio.DAL.DbContexts;
using Refugio.Entities.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refugio.Entities.Services
{
    public class EstudosRepository : IEstudosRepository
    {
        private readonly MainContext _mainContext;
        public EstudosRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public async Task<Estudo> AlterarEstudo(Estudo estudo)
        {
            if (!await _mainContext.Estudos.AnyAsync(e => e.Id == estudo.Id))
                throw new Exception("Estudo não encontrado");

            _mainContext.Estudos.Update(estudo);

            await _mainContext.SaveChangesAsync();

            return estudo;
        }

        public async Task<Estudo> DeletarEstudo(Guid idEstudo)
        {
            var estudo = await BuscarEstudo(idEstudo);

            if(estudo == null)
                throw new Exception("Estudo não encontrado");

            _mainContext.Estudos.Remove(estudo);

            await _mainContext.SaveChangesAsync();

            return estudo;
        }

        public async Task<IEnumerable<Estudo>> GetEstudos()
        {
            return await _mainContext.Estudos.ToListAsync();
        }
        public async Task<IEnumerable<Estudo>> GetEstudos(string categoria, string tipo)
        {
            
            var estudos = await GetEstudos();

            if (!string.IsNullOrWhiteSpace(categoria))
                estudos = estudos.Where(e => e.Categoria == categoria);

            if (!string.IsNullOrWhiteSpace(tipo))
                estudos = estudos.Where(e => e.Tipo == tipo);

            return estudos.ToList();
        }

        public async Task<Estudo> InserirEstudo(Estudo estudo)
        {
            await _mainContext.Estudos.AddAsync(estudo);

            await _mainContext.SaveChangesAsync();

            return estudo;
        }

        public async Task<Estudo> BuscarEstudo(Guid idEstudo)
        {
            var estudo = await _mainContext.Estudos
                                .FirstOrDefaultAsync(e => e.Id == idEstudo);

            return estudo;
        }
    }
}
