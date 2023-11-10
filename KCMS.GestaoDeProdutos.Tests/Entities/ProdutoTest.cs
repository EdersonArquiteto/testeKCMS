using FluentAssertions;
using KCMS.GestaoDeProdutos.Domain.Entities;
using Xunit;

namespace KCMS.GestaoDeProdutos.Tests.Entities
{
    public class ProdutoTest
    {
        [Fact]
        public void ValidarIdTest()
        {
            var produto = new Produto
            {
                Id = Guid.Empty
            };
            produto.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Id é obrigatório"))
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void ValidarNomeTest()
        {
            var produto = new Produto
            {
                NomeProduto = string.Empty,
            };
            produto.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Nome do Produto é inválido"))
                .Should()
                .NotBeNull();
        }
        [Fact]
        public void ValidarDescricaoTest()
        {
            var produto = new Produto
            {
                Descricao = string.Empty,
            };
            produto.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Descrição do Produto é inválido"))
                .Should()
                .NotBeNull();
        }
        
    }
}
