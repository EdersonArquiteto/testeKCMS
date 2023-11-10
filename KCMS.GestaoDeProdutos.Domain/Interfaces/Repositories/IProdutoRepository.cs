using KCMS.GestaoDeProdutos.Domain.Core;
using KCMS.GestaoDeProdutos.Domain.Entities;

namespace KCMS.GestaoDeProdutos.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository :IBaseRepository<Produto,Guid>
    {
        List<Produto> ListProdutosByCategoriaId(Guid id);
    }
}
