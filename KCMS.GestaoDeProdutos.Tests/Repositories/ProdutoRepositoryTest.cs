using Bogus;
using FluentAssertions;
using KCMS.GestaoDeProdutos.Domain.Entities;
using KCMS.GestaoDeProdutos.Domain.Interfaces.Repositories;
using Xunit;

namespace KCMS.GestaoDeProdutos.Tests.Repositories
{
    public class ProdutoRepositoryTest
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoRepositoryTest(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [Fact]
        public void TestCreate()
        {
            var produto = CreateProduto();
            var produtoById = _produtoRepository.GetById(produto.Id);
            produtoById.Should().NotBeNull();
            produtoById.Descricao.Should().Be(produto.Descricao);
            produtoById.Valor.Should().Be(produto.Valor);
            produtoById.Categoria.NomeCategoria.Should().Be(produto.Categoria.NomeCategoria);
            produtoById.CategoriaId.Should().Be(produto.CategoriaId);
        }

        [Fact]
        public void TestUpdate()
        {
            var produto = CreateProduto();

            produto.NomeProduto = "Nome Produto Atualizado";
            produto.Descricao = "Descrição do Produto Atualizada";
            produto.Valor= 1;
            
            var produtoById = _produtoRepository.GetById(produto.Id);

            produtoById.Should().NotBeNull();
            produtoById.Descricao.Should().Be(produto.Descricao);
            produtoById.Valor.Should().Be(produto.Valor);
            produtoById.Categoria.NomeCategoria.Should().Be(produto.Categoria.NomeCategoria);
            produtoById.CategoriaId.Should().Be(produto.CategoriaId);
        }

        [Fact]
        public void TestDelete()
        {
            var produto = CreateProduto();

            _produtoRepository.Delete(produto);
            var produtoById = _produtoRepository.GetById(produto.Id);
            produtoById.Should().BeNull();
        }

        private Produto CreateProduto()
        {
            var faker = new Faker("pt_BR");

            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                NomeProduto = "novo Produto",
                Descricao = "Produto lançamento",
                Valor = 150,
                Categoria= new Categoria
                {
                    Id = Guid.NewGuid(),
                    NomeCategoria= "Nova Categoria"
                }
            };

            _produtoRepository.Create(produto);
            return produto;
        }
    }
}
