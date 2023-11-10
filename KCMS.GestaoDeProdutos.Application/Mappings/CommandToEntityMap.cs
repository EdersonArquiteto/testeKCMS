using AutoMapper;
using AutoMapper.Configuration.Conventions;
using KCMS.GestaoDeProdutos.Application.DTO.Input;
using KCMS.GestaoDeProdutos.Application.DTO.Output;
using KCMS.GestaoDeProdutos.Domain.Entities;
using System.Xml;

namespace KCMS.GestaoDeProdutos.Application.Mappings
{
    public class CommandToEntityMap : Profile
    {
        public CommandToEntityMap() {
            CreateMap<ProdutoInput, Produto>()
                .ForPath(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria))
                .ForMember(x => x.CategoriaId, c => c.MapFrom(p => p.Categoria.Id))
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                })             
                .ReverseMap();

            CreateMap<CategoriaInput, Categoria>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                }).ReverseMap();
            CreateMap<Categoria, CategoriaOutput>().ReverseMap();

            CreateMap<Produto, ProdutoOutput>()
                .ForPath(dest => dest.categoriaOutput.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.NomeCategoria))
                .ForPath(dest => dest.categoriaOutput.Id, opt => opt.MapFrom(src => src.Categoria.Id));

            CreateMap<ProdutoOutput, Produto>()
                .ForPath(dest => dest.Categoria.NomeCategoria, opt => opt.MapFrom(src => src.categoriaOutput.NomeCategoria))
                .ForPath(dest => dest.Categoria.Id, opt => opt.MapFrom(src => src.Id));
            //.ReverseMap();



        }
    }
}
