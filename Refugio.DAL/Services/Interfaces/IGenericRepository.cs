using Refugio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refugio.DAL.Services.Interfaces
{
    public interface IGenericRepository
    {
        Task<T> Create<T>(T entity) where T : class, BaseInterface;
        Task<T> Delete<T>(int id) where T : class, BaseInterface;
        Task<T> Find<T>(int id) where T : class, BaseInterface;
        Task<T> FindByUser<T>(int id, string usuario) where T : class, BaseInterface, BaseUser;
        Task<IList<T>> GetALL<T>() where T : class, BaseInterface;
        Task<IList<T>> GetAllByUser<T>(string usuario) where T : class, BaseInterface, BaseUser;
        Task<T> Update<T>(T entity) where T : class, BaseInterface;
    }
}
