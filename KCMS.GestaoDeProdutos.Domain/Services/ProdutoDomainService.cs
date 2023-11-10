using KCMS.GestaoDeProdutos.Domain.Entities;
using KCMS.GestaoDeProdutos.Domain.Interfaces.Repositories;
using KCMS.GestaoDeProdutos.Domain.Interfaces.Services;

namespace KCMS.GestaoDeProdutos.Domain.Services
{
    public class ProdutoDomainService : IBaseDomainService<Produto,Guid>, IProdutoDomainService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoDomainService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Create(Produto produto)
        {
            _produtoRepository.Create(produto);
        }
        public void Update(Produto produto)
        {
            _produtoRepository.Update(produto);
        }
        public void Delete(Produto produto)
        {
            _produtoRepository.Delete(produto);
        }

        public async Task<IList<Produto>> GetAll()
        {
            var produtos = _produtoRepository.GetAll();
           return produtos;
        }

        public async Task<Produto> GetById(Guid id)
        {
            var produto = _produtoRepository.GetById(id);
            return produto;
        }

        public async Task<IList<Produto>> ListProdutosPorCategoria(Guid id)
        {
            var produtos = _produtoRepository.ListProdutosByCategoriaId(id);
            return produtos;
        }
    }
}
