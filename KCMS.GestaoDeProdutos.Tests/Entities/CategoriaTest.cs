using FluentAssertions;
using KCMS.GestaoDeProdutos.Domain.Entities;
using Xunit;

namespace KCMS.GestaoDeProdutos.Tests.Entities
{
    public class CategoriaTest
    {
        [Fact]
        public void ValidarIdTest()
        {
            var categoria = new Categoria
            {
                Id = Guid.Empty
            };
            categoria.Validate
                .Errors
                .FirstOrDefault(er => er.ErrorMessage.Contains("Id é obrigatório"))
                .Should()
                .NotBeNull();
        }

        [Fact]
        public void ValidarNomeTest()
        {
            var categoria = new Categoria
            {
                NomeCategoria = string.Empty,
            };
            categoria.Validate
                .Errors
                .FirstOrDefault(er=>er.ErrorMessage.Contains("Nome de categoria inválido"))
                .Should()
                .NotBeNull();
        }
       

    }
}
