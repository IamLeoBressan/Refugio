using Refugio.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Refugio.DAL.Services.Interfaces
{
    public interface IEvolucaoRepository : IGenericRepository
    {
        Task<IList<Evolucao>> GetAllCompleteByUser(string user);
        Task<Evolucao> FindCompleteByUser(string usuario, int Id);
        Task<bool> ExisteEvolucaoNaData(string user, DateTime data);
    }
}
