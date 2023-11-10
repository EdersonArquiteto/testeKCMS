using FluentValidation.Results;

namespace KCMS.GestaoDeProdutos.Domain.Core
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
        ValidationResult Validate { get; }
    }
}
