
using Bogus;
using KCMS.GestaoDeProdutos.Domain.Core;
using KCMS.GestaoDeProdutos.Domain.Entities;
using KCMS.GestaoDeProdutos.Domain.Services;
using Xunit;

namespace KCMS.GestaoDeProdutos.Tests.Services
{
    public class CategoriaDomainServiceTest
    {
        private readonly CategoriaDomainService _categoriaDomainService;

        public CategoriaDomainServiceTest(CategoriaDomainService categoriaDomainService)
        {
            _categoriaDomainService = categoriaDomainService;
        }
        [Fact]
        public void TestCriarCategoria()
        {
            try
            {
                var categoria = NewCategoria();
                _categoriaDomainService.Create(categoria);
            }catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [Fact]
        public void TestNomeCategoria()
        {
            var categoria = NewCategoria();
            _categoriaDomainService.Create(categoria);

            //para passar no teste deverá retornar uma execção do tipo DomainException
            Assert.Throws<DomainException>(()=>_categoriaDomainService.Create(categoria));

        }

        private Categoria NewCategoria()
        {
            var faker = new Faker("pt_BR");
            return new Categoria
            {
                Id = Guid.NewGuid(),
                NomeCategoria = "Test"
            };
        }
    }
}
