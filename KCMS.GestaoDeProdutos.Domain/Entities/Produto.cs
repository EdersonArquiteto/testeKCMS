using FluentValidation.Results;
using KCMS.GestaoDeProdutos.Domain.Core;
using KCMS.GestaoDeProdutos.Domain.Validations;

namespace KCMS.GestaoDeProdutos.Domain.Entities
{
    public class Produto : IEntity<Guid>
    {
        
        public Guid Id { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public ValidationResult Validate => new ProdutoValidation().Validate(this);
    }
}
