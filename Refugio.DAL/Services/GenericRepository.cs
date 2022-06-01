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
    public class GenericRepository : IGenericRepository
    {
        private readonly MainContext _mainContext;
        public GenericRepository(MainContext mainContext)
        {
            _mainContext = mainContext;
        }

        public async Task<T> Find<T>(int id) where T : class, BaseInterface
        {
            var estudo = await _mainContext.Set<T>().FindAsync(id);

            return estudo;
        }

        public async Task<IList<T>> GetALL<T>() where T : class, BaseInterface
        {
            return await _mainContext.Set<T>().ToListAsync();
        }
        public async Task<T> Update<T>(T entity) where T : class, BaseInterface
        {
            if (!await _mainContext.Set<T>().AnyAsync(e => e.Id == entity.Id))
                throw new Exception("Não encontrado");

            _mainContext.Set<T>().Update(entity);

            await _mainContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> FindByUser<T>(int id, string usuario) where T : class, BaseInterface, BaseUser
        {
            var estudo = await _mainContext.Set<T>()
                .Where(c => c.Usuario == usuario)
                .FirstOrDefaultAsync(c => c.Id == id);

            return estudo;
        }

        public async Task<IList<T>> GetAllByUser<T>(string usuario) where T : class, BaseInterface, BaseUser
        {
            return await _mainContext.Set<T>()
                        .Where(c => c.Usuario == usuario)
                        .ToListAsync();
        }

        public async Task<T> Create<T>(T entity) where T : class, BaseInterface
        {
            await _mainContext.Set<T>().AddAsync(entity);
            await _mainContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Delete<T>(int id) where T : class, BaseInterface
        {
            var entity = await Find<T>(id);

            if (entity == null)
                throw new Exception("Não encontrado");

            _mainContext.Set<T>().Remove(entity);

            await _mainContext.SaveChangesAsync();

            return entity;
        }
    }
}
