using Skynetz.Domain.Models;
using System;
using Xunit;

namespace Skynetz.Test
{
    public class TarefaTest
    {
        public TarefaTest() { }

        [Theory]
        [InlineData("011","016", 1.90f, 10, 19)]
        [InlineData("016","011", 2.90f, 10, 29)]
        [InlineData("011","017", 1.70f, 10, 17)]
        [InlineData("017","011", 2.70f, 10, 27)]
        [InlineData("011","018", 0.90f, 10, 9)]
        [InlineData("018","011", 1.90f, 10, 19)]
        public void Should_Return_Success_CalcularTarifa(string origem, string destino, decimal tarifaMinuto, int minutos, decimal expected)
        {
            var tarifa = new Tarifa(origem, destino, tarifaMinuto);
            var valorTarifa = tarifa.CalcularTarifa(minutos);

            Assert.Equal(expected, valorTarifa);
        }
    }
}
