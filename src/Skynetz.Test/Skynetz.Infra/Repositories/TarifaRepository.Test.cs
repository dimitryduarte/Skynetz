using Moq;
using Skynetz.Domain.Models;
using Skynetz.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Skynetz.Test.Skynetz.Infra.Repositories
{
    public class TarifaRepositoryTest
    {
        [InlineData("018", "011", 1.90f, 10)]
        [InlineData("011", "016", 1.90f, 10)]
        [InlineData("016", "011", 2.90f, 10)]
        [InlineData("011", "017", 1.70f, 10)]
        [InlineData("017", "011", 2.70f, 10)]
        [InlineData("011", "018", 0.90f, 10)]
        [InlineData("018", "011", 1.90f, 10)]
        public void Should_Return_Success_Tarifa_GetAll(string origem, string destino, decimal tarifaMinuto, int id)
        {
            var data = new List<Tarifa> {
              new Tarifa {Origem = origem, Destino = destino, TarifaMinuto = tarifaMinuto, Id = id},
              new Tarifa {Origem = origem, Destino = destino, TarifaMinuto = tarifaMinuto, Id = id},
              new Tarifa {Origem = origem, Destino = destino, TarifaMinuto = tarifaMinuto, Id = id},
            };

            var _mock = new MockHelper<Tarifa>();
            var mockContext = _mock.MoqContext(data);

            //Act
            var repository = new Mock<TarifaRepository>(mockContext.Object);

            var tarifas = repository.Object.GetAll();

            //Assert
            Assert.NotNull(tarifas);

            foreach (var item in tarifas)
            {
                Assert.Equal(id, item.Id);
                Assert.Equal(origem, item.Origem);
                Assert.Equal(destino, item.Destino);
                Assert.Equal(tarifaMinuto, item.TarifaMinuto);
            }
        }

        [InlineData("018", "011", 1.90f, 10)]
        [InlineData("011", "016", 1.90f, 10)]
        [InlineData("016", "011", 2.90f, 10)]
        [InlineData("011", "017", 1.70f, 10)]
        [InlineData("017", "011", 2.70f, 10)]
        [InlineData("011", "018", 0.90f, 10)]
        [InlineData("018", "011", 1.90f, 10)]
        public void Should_Return_Success_Tarifa_GetById(string origem, string destino, decimal tarifaMinuto, int id)
        {
            var data = new List<Tarifa> {
              new Tarifa {Origem = origem, Destino = destino, TarifaMinuto = tarifaMinuto, Id = id},
              new Tarifa {Origem = origem, Destino = destino, TarifaMinuto = tarifaMinuto, Id = 99998},
              new Tarifa {Origem = origem, Destino = destino, TarifaMinuto = tarifaMinuto, Id = 99999},
            };

            var _mock = new MockHelper<Tarifa>();
            var mockContext = _mock.MoqContext(data);

            //Act
            var repository = new Mock<TarifaRepository>(mockContext.Object);

            var tarifa = repository.Object.GetById(id);

            //Assert
            Assert.NotNull(tarifa);
            Assert.Equal(id, tarifa.Id);
            Assert.Equal(origem, tarifa.Origem);
            Assert.Equal(destino, tarifa.Destino);
            Assert.Equal(tarifaMinuto, tarifa.TarifaMinuto);
        }

        [InlineData("018", "011", 1.90f, 10)]
        [InlineData("011", "016", 1.90f, 10)]
        [InlineData("016", "011", 2.90f, 10)]
        [InlineData("011", "017", 1.70f, 10)]
        [InlineData("017", "011", 2.70f, 10)]
        [InlineData("011", "018", 0.90f, 10)]
        [InlineData("018", "011", 1.90f, 10)]
        public void Should_Return_Failure_Tarifa_GetAll(string origem, string destino, decimal tarifaMinuto, int id)
        {
            var data = new List<Tarifa> {};

            var _mock = new MockHelper<Tarifa>();
            var mockContext = _mock.MoqContext(data);

            //Act
            var repository = new Mock<TarifaRepository>(mockContext.Object);

            var tarifas = repository.Object.GetAll();

            //Assert
            Assert.NotNull(tarifas);

            foreach (var item in tarifas)
            {
                Assert.Equal(id, item.Id);
                Assert.Equal(origem, item.Origem);
                Assert.Equal(destino, item.Destino);
                Assert.Equal(tarifaMinuto, item.TarifaMinuto);
            }
        }

        [InlineData("018", "011", 1.90f, 10)]
        [InlineData("011", "016", 1.90f, 10)]
        [InlineData("016", "011", 2.90f, 10)]
        [InlineData("011", "017", 1.70f, 10)]
        [InlineData("017", "011", 2.70f, 10)]
        [InlineData("011", "018", 0.90f, 10)]
        [InlineData("018", "011", 1.90f, 10)]
        public void Should_Return_Failure_Tarifa_GetById(string origem, string destino, decimal tarifaMinuto, int id)
        {
            var data = new List<Tarifa> {
              new Tarifa {Origem = origem, Destino = destino, TarifaMinuto = tarifaMinuto, Id = 99997},
              new Tarifa {Origem = origem, Destino = destino, TarifaMinuto = tarifaMinuto, Id = 99998},
              new Tarifa {Origem = origem, Destino = destino, TarifaMinuto = tarifaMinuto, Id = 99999},
            };

            var _mock = new MockHelper<Tarifa>();
            var mockContext = _mock.MoqContext(data);

            //Act
            var repository = new Mock<TarifaRepository>(mockContext.Object);

            var tarifa = repository.Object.GetById(id);

            //Assert
            Assert.NotNull(tarifa);
            Assert.Equal(id, tarifa.Id);
            Assert.Equal(origem, tarifa.Origem);
            Assert.Equal(destino, tarifa.Destino);
            Assert.Equal(tarifaMinuto, tarifa.TarifaMinuto);
        }
    }
}
