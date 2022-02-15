using System;
using Xunit;
using Refugio.Entities;
namespace Refugio.Testes
{
    public class ObjetivoTest
    {
        [Fact]
        public void DiasAteObjetivoTest()
        {
            // Arrange
            var Objetivo = new Objetivo()
            {
                DataFim = new DateTime(2022, 03, 01),
                DataInicio = new DateTime()
            };

            var excpected = (Objetivo.DataFim - Objetivo.DataInicio).Days;

            // Act
            var actual = Objetivo.DiasAteFim();

            //Assert
            Assert.Equal(excpected, actual);

        }
    }
}
