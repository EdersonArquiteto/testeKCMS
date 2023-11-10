using KCMS.GestaoDeProdutos.Application.DTO.Input;
using KCMS.GestaoDeProdutos.Application.DTO.Output;

namespace KCMS.GestaoDeProdutos.Application.Interface
{
    public interface ICategoriaAppService
    {
        Task Create(CategoriaInput categoriaInput);
        Task Update(CategoriaOutput categoriaOutput);
        Task Delete(CategoriaOutput categoriaOutput);
        Task<IList<CategoriaOutput>> GetAll();
        Task<CategoriaOutput> GetById(Guid id);
        
    }
}

