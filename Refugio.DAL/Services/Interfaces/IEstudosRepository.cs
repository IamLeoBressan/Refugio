using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Refugio.Entities.Services.Interfaces
{
    public interface IEstudosRepository
    {
        Task<IEnumerable<Estudo>> GetEstudos();
        Task<IEnumerable<Estudo>> GetEstudos(string categoria, string tipo);
        Task<Estudo> BuscarEstudo(Guid idEstudo);
        Task<Estudo> InserirEstudo(Estudo estudo);
        Task<Estudo> AlterarEstudo(Estudo estudo);
        Task<Estudo> DeletarEstudo(Guid idEstudo);
    }
}