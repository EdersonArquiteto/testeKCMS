using KCMS.GestaoDeProdutos.Domain.Entities;

namespace KCMS.GestaoDeProdutos.Domain.Interfaces.Services
{
    public interface IProdutoDomainService
    {
        Task<IList<Produto>> ListProdutosPorCategoria(Guid id);
    }
}
