using Bogus;
using FluentAssertions;
using KCMS.GestaoDeProdutos.Domain.Entities;
using KCMS.GestaoDeProdutos.Domain.Interfaces.Repositories;
using Xunit;

namespace KCMS.GestaoDeProdutos.Tests.Repositories
{
    public class CategoriaRepositoryTest
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaRepositoryTest(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }


        [Fact]
        public void TestCreate()
        {
            var categoria = CreateCategoria();
            var categoriaById = _categoriaRepository.GetById(categoria.Id);
            categoriaById.Should().NotBeNull();
            categoriaById.NomeCategoria.Should().Be(categoria.NomeCategoria);
        }

        [Fact]
        public void TestUpdate()
        {
            var categoria =CreateCategoria();
            var faker = new Faker("pt_BR");

            categoria.NomeCategoria = "Nome Categoria Atulizado";
            _categoriaRepository.Update(categoria);

            var categoriaById = _categoriaRepository.GetById(categoria.Id);
            categoriaById.Should().NotBeNull();
            categoriaById.NomeCategoria.Should().Be(categoria.NomeCategoria);
        }

        [Fact]
        public void TestDelete()
        {
            var categoria = CreateCategoria();
            _categoriaRepository.Delete(categoria);
            var categoById = _categoriaRepository.GetById(categoria.Id);
            categoById.Should().BeNull();
        }

        [Fact]
        public void TestGetAll()
        {
            var categoria = CreateCategoria();
            var lista = _categoriaRepository.GetAll();
            lista.FirstOrDefault(c => c.Id.Equals(categoria.Id)).Should().NotBeNull();
        }

        private Categoria CreateCategoria()
        {
            var faker = new Faker("pt_BR");
            var categoria = new Categoria
            {
                Id= Guid.NewGuid(),
                NomeCategoria= "Teste Categoria",

            };
            _categoriaRepository.Create(categoria);
            return categoria;

        }

    }
}
