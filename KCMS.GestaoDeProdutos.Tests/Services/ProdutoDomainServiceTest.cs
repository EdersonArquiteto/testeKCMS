using KCMS.GestaoDeProdutos.Domain.Entities;
using KCMS.GestaoDeProdutos.Domain.Services;
using Xunit;

namespace KCMS.GestaoDeProdutos.Tests.Services
{
    public class ProdutoDomainServiceTest
    {
        private readonly ProdutoDomainService _produtoDomainService;

        public ProdutoDomainServiceTest(ProdutoDomainService produtoDomainService)
        {
            _produtoDomainService = produtoDomainService;
        }
        [Fact]
        public void TestCriarProduto()
        {
            try
            {
                var produto = NewProduto();
                _produtoDomainService.Create(produto);
            }
            catch (Exception e)
            {
                //Gerando um resultado de falha!
                Assert.Fail(e.Message);
            }
        }

       

        private Produto NewProduto()
        {
            return new Produto
            {
                Id = Guid.NewGuid(),
                NomeProduto = "Laptop DELL",
                Descricao = "",
                Valor = 4000,
                Categoria = new Categoria
                {
                    Id = Guid.NewGuid(),
                    NomeCategoria = "Informatica"
                }
            };
        }
    }
}
