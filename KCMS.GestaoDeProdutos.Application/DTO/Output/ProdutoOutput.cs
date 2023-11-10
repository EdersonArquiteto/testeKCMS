namespace KCMS.GestaoDeProdutos.Application.DTO.Output
{
    public class ProdutoOutput
    {
        public Guid Id { get; set; }
        public string? NomeProduto { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }
        public Guid CategoriaId { get; set; }
        public CategoriaOutput categoriaOutput { get; set; }
    }
}
