using FluentValidation;
using KCMS.GestaoDeProdutos.Domain.Entities;

namespace KCMS.GestaoDeProdutos.Domain.Validations
{
    public class CategoriaValidation : AbstractValidator<Categoria>
    {
        public CategoriaValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id é obrigatório.");

            RuleFor(c => c.NomeCategoria)
                .NotEmpty()
                .Length(6, 150)
                .WithMessage("Nome de de Categoria inválido.");
        }
    }
}
