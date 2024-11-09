using CP3.Data.AppData;
using CP3.Data.Repositories;
using CP3.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace CP3.Tests
{
    public class BarcoRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly BarcoRepository _barcoRepository;

        public BarcoRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "BarcoDatabase")
                .Options;
            _context = new ApplicationContext(_options);
            _barcoRepository = new BarcoRepository(_context);
        }

        [Fact]
        public void Adicionar_DeveAdicionarBarco()
        {
            // Arrange
            var barco = new BarcoEntity { Id = 1, Nome = "Barco1", Modelo = "Modelo1", Ano = 2020, Tamanho = 30.5 };

            // Act
            var result = _barcoRepository.Adicionar(barco);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(barco, result);
        }

        [Fact]
        public void ObterTodos_DeveRetornarTodosOsBarcos()
        {
            // Arrange
            var barcos = new List<BarcoEntity>
            {
                new BarcoEntity { Id = 1, Nome = "Barco1", Modelo = "Modelo1", Ano = 2020, Tamanho = 30.5 },
                new BarcoEntity { Id = 2, Nome = "Barco2", Modelo = "Modelo2", Ano = 2021, Tamanho = 40.5 }
            };
            _context.Barco.AddRange(barcos);
            _context.SaveChanges();

            // Act
            var result = _barcoRepository.ObterTodos();

            // Assert
            Assert.Equal(barcos, result);
        }

        // Outros testes para os métodos da camada de repositório...
    }
}
