using KCMS.GestaoDeProdutos.Application.DTO.Output;

namespace KCMS.GestaoDeProdutos.Application.DTO.Input
{
    public class ProdutoInput
    {
        public string? NomeProduto { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }
        public CategoriaOutput Categoria { get; set; }
      
    }
}
