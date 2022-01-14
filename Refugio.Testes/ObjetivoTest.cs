using System;
using Xunit;
using Refugio.Entities;
namespace Refugio.Testes
{
    public class ObjetivoTest
    {
        [Fact]
        public void DiasAteObjetivo()
        {
            var Objetivo = new Objetivo()
            {
                DataFim = new DateTime(2022, 03, 01),
                DataInicio = new DateTime()
            };

            var diasFaltando = (Objetivo.DataFim - Objetivo.DataInicio).Days;

            Assert.Equal(diasFaltando, Objetivo.DiasAteFim());

        }
    }
}
