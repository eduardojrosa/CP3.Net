using CP3.Application.Services;
using CP3.Domain.Entities;
using CP3.Domain.Interfaces;
using CP3.Domain.Interfaces.Dtos;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CP3.Tests
{
    public class BarcoApplicationServiceTests
    {
        private readonly Mock<IBarcoRepository> _repositoryMock;
        private readonly BarcoApplicationService _barcoService;

        public BarcoApplicationServiceTests()
        {
            _repositoryMock = new Mock<IBarcoRepository>();
            _barcoService = new BarcoApplicationService(_repositoryMock.Object);
        }

        [Fact]
        public void ObterTodosBarcos_DeveRetornarTodosOsBarcos()
        {
            // Arrange
            var barcos = new List<BarcoEntity>
            {
                new BarcoEntity { Id = 1, Nome = "Barco1", Modelo = "Modelo1", Ano = 2020, Tamanho = 30.5 },
                new BarcoEntity { Id = 2, Nome = "Barco2", Modelo = "Modelo2", Ano = 2021, Tamanho = 40.5 }
            };
            _repositoryMock.Setup(repo => repo.ObterTodos()).Returns(barcos);

            // Act
            var result = _barcoService.ObterTodosBarcos();

            // Assert
            Assert.Equal(barcos, result);
        }

        // Outros testes para os métodos da camada de aplicação...
    }
}
