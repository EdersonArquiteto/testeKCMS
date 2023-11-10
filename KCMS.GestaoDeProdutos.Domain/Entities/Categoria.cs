using FluentValidation.Results;
using KCMS.GestaoDeProdutos.Domain.Core;
using KCMS.GestaoDeProdutos.Domain.Validations;

namespace KCMS.GestaoDeProdutos.Domain.Entities
{
    public class Categoria : IEntity<Guid>
    {
     
        public Guid Id { get; set; }
        public string NomeCategoria { get; set; }
        public ICollection<Produto> Produtos { get; set; }
        public ValidationResult Validate =>new CategoriaValidation().Validate(this);
    }
}
