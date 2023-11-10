namespace KCMS.GestaoDeProdutos.Application.DTO.Output
{
    public class CategoriaOutput
    {
        public Guid Id { get; set; }
        public string NomeCategoria { get; set; }
        ProdutoOutput Produtos { get; set; }
    }
}
