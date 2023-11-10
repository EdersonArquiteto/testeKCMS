using KCMS.GestaoDeProdutos.Domain.Entities;
using KCMS.GestaoDeProdutos.Domain.Interfaces.Repositories;
using KCMS.GestaoDeProdutos.Domain.Interfaces.Services;

namespace KCMS.GestaoDeProdutos.Domain.Services
{
    public class CategoriaDomainService :IBaseDomainService<Categoria, Guid>
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaDomainService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Create(Categoria categoria)
        {
           _categoriaRepository.Create(categoria);
        }
        public void Update(Categoria categoria)
        {
            _categoriaRepository.Update(categoria);
        }

        public void Delete(Categoria categoria)
        {
           _categoriaRepository.Delete(categoria);
        }
        public async Task<IList<Categoria>> GetAll()
        {
          var categorias = _categoriaRepository.GetAll();
          return categorias.ToList();
        }

        public async Task<Categoria> GetById(Guid id)
        {
            var categoria = _categoriaRepository.GetById(id);
            return categoria;
        }

       
    }
}
