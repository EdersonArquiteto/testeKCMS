using FluentValidation;
using KCMS.GestaoDeProdutos.Domain.Entities;

namespace KCMS.GestaoDeProdutos.Domain.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation() { 
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("Id é obrigatório.");

            RuleFor(p=>p.NomeProduto)
                .NotEmpty()
                .Length(6,150)
                .WithMessage("Nome de Produto inválido");
            RuleFor(p => p.Descricao)
                .NotEmpty()
                .Length(6, 255)
                .WithMessage("Descrição do Produto inválido");
            RuleFor(p => p.Valor)
               .NotEmpty()
               .WithMessage("O valor é obrigatório.");

            RuleFor(p => p.Categoria)
               .NotEmpty()
               .WithMessage("Categoria inválido");
        }
    }
}
