using Refugio.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Refugio.DAL.Services.Interfaces
{
    public interface IEvolucaoRepository : IGenericRepository
    {
        Task<IList<Evolucao>> GetAllComplete();
    }
}
