using Skynetz.Domain.Models;
using System;
using Xunit;

namespace Skynetz.Test
{
    public class PlanoTest
    {
        public PlanoTest() { }

        [Theory]
        [InlineData("FaleMais 30", 30, 10, 0)]
        [InlineData("FaleMais 30", 30, 30, 0)]
        [InlineData("FaleMais 30", 30, 40, 10)]
        [InlineData("FaleMais 60", 60, 30, 0)]
        [InlineData("FaleMais 60", 60, 60, 0)]
        [InlineData("FaleMais 60", 60, 70, 10)]
        [InlineData("FaleMais 120", 120, 90, 0)]
        [InlineData("FaleMais 120", 120, 120, 0)]
        [InlineData("FaleMais 120", 120, 150, 30)]
        public void Should_Return_Success_DescontarMinutos(string nome, int maxMinutos, int minutos, decimal expected)
        {
            var plano = new Plano(nome, maxMinutos);
            var valorTarifa = plano.DescontarMinutos(minutos);

            Assert.Equal(expected, valorTarifa);
        }
    }
}
