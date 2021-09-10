using Refugio.DAL.DbContexts;
using Refugio.DAL.Services.Interfaces;

namespace Refugio.DAL.Services
{
    public class ObjetivosRepository: GenericRepository, IObjetivosRepository
    {
        
        public ObjetivosRepository(MainContext mainContext) : base(mainContext)
        {
            
        }
    }
}
