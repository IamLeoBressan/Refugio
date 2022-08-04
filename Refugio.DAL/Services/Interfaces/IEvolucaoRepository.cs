using Refugio.Entities;
using Refugio.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Refugio.DAL.Services.Interfaces
{
    public interface IEvolucaoRepository : IGenericRepository
    {
        Task<IList<Evolucao>> GetAllCompleteByUser(string user);                      
        IList<Evolucao> GetAllCompleteByUser(string user, Paginacao filtrosLista, out int quantidadeTotalItens);
        Task<Evolucao> FindCompleteByUser(string usuario, int Id);
        Task<bool> ExisteEvolucaoNaData(string user, DateTime data);
        Task<List<string>> GetGrupoMesesEvolucoes(string usuario);

        Task<List<Evolucao>> GetEvolucoesFiltradas(string user, int ano, int mes);
    }
}
