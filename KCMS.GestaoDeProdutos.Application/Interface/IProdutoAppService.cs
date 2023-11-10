using KCMS.GestaoDeProdutos.Application.DTO.Input;
using KCMS.GestaoDeProdutos.Application.DTO.Output;

namespace KCMS.GestaoDeProdutos.Application.Interface
{
    public interface IProdutoAppService
    {
        Task Create(ProdutoInput produtoInput);
        Task Update(ProdutoOutput produtoOutput);
        Task Delete(ProdutoOutput produtoOutput);
        Task<IList<ProdutoOutput>> GetAll();
        Task<ProdutoOutput> GetById(Guid id);
        Task<IList<ProdutoOutput>> GetByCategoriaId(Guid id);
    }
}
