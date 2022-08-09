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

        public async Task<Evolucao> UpdateEvolucao(Evolucao evolucao)
        {
            await RemoveListaDificuldades(evolucao);
            await RemoveListaImagens(evolucao);

            var evolucaoDB = _mainContext.Evolucoes.Include(e => e.Dificuldades).Include(e => e.Imagens)
            .Where(c => c.Id.Equals(evolucao.Id)).FirstOrDefault();

            _mainContext.Entry<Evolucao>(evolucaoDB).State = EntityState.Detached;
            _mainContext.Entry<Evolucao>(evolucao).State = EntityState.Modified;

            evolucao.Imagens = evolucao.Imagens.Where(e => e.Id == null).ToList();

            AjustaStadoEntity(evolucao.Imagens);
            AjustaStadoEntity(evolucao.Dificuldades);

            await _mainContext.SaveChangesAsync();

            return evolucao;
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

        private async Task RemoveListaDificuldades(Evolucao evolucao)
        {
            var dificuldadesRemover = _mainContext.Dificuldades.Where(e => e.EvolucaoId == evolucao.Id).ToList();

            var dificuldadesManter = evolucao.Dificuldades.Where(e => e.Id != null).ToList();

            dificuldadesRemover = dificuldadesRemover.Where(e => !dificuldadesManter.Any(j => j.Id == e.Id)).ToList();

            foreach (var dificuldade in dificuldadesRemover)
            {
                _mainContext.Dificuldades.Remove(dificuldade);
            }

            await _mainContext.SaveChangesAsync();
        }
        private async Task RemoveListaImagens(Evolucao evolucao)
        {
            var imagensRemover = _mainContext.Imagens.ToList();

            var imagensManter = evolucao.Imagens.Where(e => e.Id != null).ToList();

            imagensRemover = imagensRemover.Where(e => !imagensManter.Any(j => j.Id == e.Id) && e.EvolucaoId == evolucao.Id).ToList();

            foreach (var imagem in imagensRemover)
            {
                _mainContext.Imagens.Remove(imagem);
            }

            await _mainContext.SaveChangesAsync();
        }
    }
}
