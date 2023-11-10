using AutoMapper;
using FluentValidation;
using KCMS.GestaoDeProdutos.Application.DTO.Input;
using KCMS.GestaoDeProdutos.Application.DTO.Output;
using KCMS.GestaoDeProdutos.Application.Interface;
using KCMS.GestaoDeProdutos.Domain.Entities;
using KCMS.GestaoDeProdutos.Domain.Services;

namespace KCMS.GestaoDeProdutos.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IMapper _mapper;
        private readonly ProdutoDomainService _produtoDomainService;

        public ProdutoAppService(IMapper mapper, ProdutoDomainService produtoDomainService)
        {
            _mapper = mapper;
            _produtoDomainService = produtoDomainService;
        }

        public async Task Create(ProdutoInput produtoInput)
        {
            var produto = _mapper.Map<Produto>(produtoInput);
            var validate = produto.Validate;
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            _produtoDomainService.Create(produto);
        }

        public async Task Delete(ProdutoOutput produtoOutput)
        {
            var produto = _mapper.Map<Produto>(produtoOutput);
            _produtoDomainService.Delete(produto);
        }

        public async Task<IList<ProdutoOutput>> GetAll()
        {
            var produtos = await _produtoDomainService.GetAll();
            return _mapper.Map<IList<ProdutoOutput>>(produtos);
        }

        public async Task<IList<ProdutoOutput>> GetByCategoriaId(Guid id)
        {
            var produtos = await _produtoDomainService.ListProdutosPorCategoria(id);
            return _mapper.Map<IList<ProdutoOutput>>(produtos);
        }

        public async Task<ProdutoOutput> GetById(Guid id)
        {
            var produto = await _produtoDomainService.GetById(id);
            return _mapper.Map<ProdutoOutput>(produto);
        }

        public async Task Update(ProdutoOutput produtoOutput)
        {
            var produto = _mapper.Map<Produto>(produtoOutput);
            var validate = produto.Validate;
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);
            }
            _produtoDomainService.Update(produto);
        }
    }
}
