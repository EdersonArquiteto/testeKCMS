using AutoMapper;
using FluentValidation;
using KCMS.GestaoDeProdutos.Application.DTO.Input;
using KCMS.GestaoDeProdutos.Application.DTO.Output;
using KCMS.GestaoDeProdutos.Application.Interface;
using KCMS.GestaoDeProdutos.Domain.Entities;
using KCMS.GestaoDeProdutos.Domain.Services;

namespace KCMS.GestaoDeProdutos.Application.Services
{
    public class CategoriaAppService : ICategoriaAppService
    {
        public readonly IMapper _mapper;
        private readonly CategoriaDomainService _categoriaDomainService;
        private readonly ProdutoDomainService _produtoDomainService;

        public CategoriaAppService(IMapper mapper, CategoriaDomainService categoriaDomainService, ProdutoDomainService produtoDomainService)
        {
            _mapper = mapper;
            _categoriaDomainService = categoriaDomainService;
            _produtoDomainService = produtoDomainService;
        }

        public async Task Create(CategoriaInput categoriaInput)
        {
            var categoria = _mapper.Map<Categoria>(categoriaInput);
            var validate = categoria.Validate;
            
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
               
            }
            _categoriaDomainService.Create(categoria);
        }
        public async Task Update(CategoriaOutput categoriaOutput)
        {
            var categoria = _mapper.Map<Categoria>(categoriaOutput);
            var validate = categoria.Validate;
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            _categoriaDomainService.Update(categoria);
        }
        public async Task Delete(CategoriaOutput categoriaOutput)
        {
            var categoria = _mapper.Map<Categoria>(categoriaOutput);
            _categoriaDomainService.Delete(categoria);
        }

        
        public async Task<IList<CategoriaOutput>> GetAll()
        {
            var categorias = await _categoriaDomainService.GetAll();
            return _mapper.Map<IList<CategoriaOutput>>(categorias);
        }

        public async Task<CategoriaOutput> GetById(Guid id)
        {
            var categoria = await _categoriaDomainService.GetById(id);
            return _mapper.Map<CategoriaOutput>(categoria);

        }

       
    }
}
