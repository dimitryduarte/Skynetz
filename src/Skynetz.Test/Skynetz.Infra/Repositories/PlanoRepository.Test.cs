using Moq;
using Skynetz.Domain.Models;
using Skynetz.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Skynetz.Test.Skynetz.Infra.Repositories
{
    public class PlanoRepositoryTest
    {
        [InlineData("FaleMais 30", 10, 10)]
        [InlineData("FaleMais 30", 30, 20)]
        [InlineData("FaleMais 30", 40, 10)]
        [InlineData("FaleMais 60", 30, 10)]
        [InlineData("FaleMais 60", 60, 20)]
        [InlineData("FaleMais 60", 70, 10)]
        [InlineData("FaleMais 120", 90, 10)]
        [InlineData("FaleMais 120", 120, 20)]
        [InlineData("FaleMais 120", 150, 30)]
        public void Should_Return_Success_Plano_GetAll(string nome, int minutos, int id)
        {
            var data = new List<Plano> {
              new Plano {Id = id, Minutos = minutos, Nome = nome},
              new Plano {Id = id, Minutos = minutos, Nome = nome},
              new Plano {Id = id, Minutos = minutos, Nome = nome},
            };

            var _mock = new MockHelper<Plano>();
            var mockContext = _mock.MoqContext(data);

            //Act
            var repository = new Mock<PlanoRepository>(mockContext.Object);

            var planos = repository.Object.GetAll();

            //Assert
            Assert.NotNull(planos);

            foreach (var item in planos)
            {
                Assert.Equal(id, item.Id);
                Assert.Equal(nome, item.Nome);
                Assert.Equal(minutos, item.Minutos);
            }
        }

        [InlineData("FaleMais 30", 10, 10)]
        [InlineData("FaleMais 30", 30, 20)]
        [InlineData("FaleMais 30", 40, 10)]
        [InlineData("FaleMais 60", 30, 10)]
        [InlineData("FaleMais 60", 60, 20)]
        [InlineData("FaleMais 60", 70, 10)]
        [InlineData("FaleMais 120", 90, 10)]
        [InlineData("FaleMais 120", 120, 20)]
        [InlineData("FaleMais 120", 150, 30)]
        public void Should_Return_Failure_Plano_GetAll(string nome, int minutos, int id)
        {
            var data = new List<Plano> {};

            var _mock = new MockHelper<Plano>();
            var mockContext = _mock.MoqContext(data);

            //Act
            var repository = new Mock<PlanoRepository>(mockContext.Object);

            var planos = repository.Object.GetAll();

            //Assert
            Assert.Null(planos);
        }

        [InlineData("FaleMais 30", 10, 10)]
        [InlineData("FaleMais 30", 30, 20)]
        [InlineData("FaleMais 30", 40, 10)]
        [InlineData("FaleMais 60", 30, 10)]
        [InlineData("FaleMais 60", 60, 20)]
        [InlineData("FaleMais 60", 70, 10)]
        [InlineData("FaleMais 120", 90, 10)]
        [InlineData("FaleMais 120", 120, 20)]
        [InlineData("FaleMais 120", 150, 30)]
        public void Should_Return_Success_Plano_GetById(string nome, int minutos, int id)
        {
            var data = new List<Plano> {
              new Plano {Id = id, Minutos = minutos, Nome = nome},
              new Plano {Id = 9999, Minutos = minutos, Nome = nome},
              new Plano {Id = 9998, Minutos = minutos, Nome = nome},
            };

            var _mock = new MockHelper<Plano>();
            var mockContext = _mock.MoqContext(data);

            //Act
            var repository = new Mock<PlanoRepository>(mockContext.Object);

            var tarifa = repository.Object.GetById(id);

            //Assert
            Assert.NotNull(tarifa);
            Assert.Equal(id, tarifa.Id);
            Assert.Equal(nome, tarifa.Nome);
            Assert.Equal(minutos, tarifa.Minutos);
        }

        [InlineData("FaleMais 30", 10, 10)]
        [InlineData("FaleMais 30", 30, 20)]
        [InlineData("FaleMais 30", 40, 10)]
        [InlineData("FaleMais 60", 30, 10)]
        [InlineData("FaleMais 60", 60, 20)]
        [InlineData("FaleMais 60", 70, 10)]
        [InlineData("FaleMais 120", 90, 10)]
        [InlineData("FaleMais 120", 120, 20)]
        [InlineData("FaleMais 120", 150, 30)]
        public void Should_Return_Failure_Plano_GetById(string nome, int minutos, int id)
        {
            var data = new List<Plano> {
              new Plano {Id = 9997, Minutos = minutos, Nome = nome},
              new Plano {Id = 9999, Minutos = minutos, Nome = nome},
              new Plano {Id = 9998, Minutos = minutos, Nome = nome},
            };

            var _mock = new MockHelper<Plano>();
            var mockContext = _mock.MoqContext(data);

            //Act
            var repository = new Mock<PlanoRepository>(mockContext.Object);

            var tarifa = repository.Object.GetById(id);

            //Assert
            Assert.Null(tarifa);
        }
    }
}
