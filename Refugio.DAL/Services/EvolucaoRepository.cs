using Microsoft.EntityFrameworkCore;
using Refugio.DAL.DbContexts;
using Refugio.DAL.Services.Interfaces;
using Refugio.Entities;
using Refugio.Helpers;
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

        public IList<Evolucao> GetAllCompleteByUser(string user, Paginacao filtrosLista, out int quantidadeTotalItens)
        {
            var skip = (filtrosLista.Pagina - 1) * filtrosLista.QuantidadeItensPagina;

            quantidadeTotalItens = _mainContext.Evolucoes.Where(e => e.Usuario == user).Count();

            return _mainContext.Evolucoes
                    .Include(e => e.Dificuldades)
                    .Include(e => e.Imagens)
                    .Where(e => e.Usuario == user)
                    .OrderByDescending(e => e.DataMedicao)
                    .Skip(skip).Take(filtrosLista.QuantidadeItensPagina)
                    .AsNoTracking()
                    .ToList();
        }

        public async Task<List<string>> GetGrupoMesesEvolucoes(string user)
        {
            var listaAgrupara = await _mainContext.Evolucoes
                    .Where(e => e.Usuario == user)
                    .Select(e => $"{e.DataMedicao.Year}-{e.DataMedicao.Month.ToString().PadLeft(2, '0')}")
                    .Distinct()
                    .ToListAsync();

            return listaAgrupara;
        }

        public async Task<List<Evolucao>> GetEvolucoesFiltradas(string user, int ano, int mes)
        {
            var evolucoesFiltradas = await _mainContext.Evolucoes
                    .Where(e => e.Usuario == user && e.DataMedicao.Year == ano && e.DataMedicao.Month == mes)
                    .OrderBy(e => e.DataMedicao)
                    .ToListAsync();

            return evolucoesFiltradas;
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
