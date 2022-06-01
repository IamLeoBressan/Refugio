using Refugio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.DAL.Services.Interfaces
{
    public interface IObjetivosRepository: IGenericRepository
    {
        Task<IList<Objetivo>> GetAllObjetivosByUser(string usuario);
    }
}
