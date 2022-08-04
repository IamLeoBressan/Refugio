using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Refugio.DAL.DbContexts;
using Refugio.DAL.Services;
using Refugio.DAL.Services.Interfaces;
using Refugio.Entities;
using Refugio.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Refugio.Testes
{

    public class EvolucaoTest
    {

        private readonly IEvolucaoRepository _evolucao;

        public EvolucaoTest()
        {
            var service = new ServiceCollection();
            service.AddDbContext<MainContext>(options =>
            {
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=refugio-sql-bd;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            });

            service.AddTransient<IGenericRepository, GenericRepository>();
            service.AddTransient<IEvolucaoRepository, EvolucaoRepository>();



            var provider = service.BuildServiceProvider();
            _evolucao = provider.GetService<IEvolucaoRepository>();
        }


        [Fact]
        public async Task TestandoPaginacao()
        {
            // Arrange
            var usuario = "leowned";

            var filtros = new Paginacao()
            {
                Pagina = 2,
                QuantidadeItensPagina = 3
            };

            var skip = (filtros.Pagina - 1) * filtros.QuantidadeItensPagina;

            IList<Evolucao> excpected = await _evolucao.GetAllCompleteByUser(usuario);

            var result = excpected.Skip(skip).Take(filtros.QuantidadeItensPagina).ToList();

            // Act
            var actual = await _evolucao.GetAllCompleteByUser(usuario);

            var teste = true;

            for (int i = 0; i < result.Count; i++)
            {

                if (result[i].Id != actual[i].Id)
                    teste = false;
            }

            Assert.True(teste);
        }
    }
}
