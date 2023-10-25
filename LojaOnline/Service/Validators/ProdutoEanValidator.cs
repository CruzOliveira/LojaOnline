using Domain.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class ProdutoEanValidator : AbstractValidator<ProdutoEan>
    {
        public ProdutoEanValidator()
        {
            ////EXEMPLO
            //RuleFor(c => c.Login)
            //      .NotEmpty()
            //      .WithMessage("Login n�o pode ser nulo.");
        }
    }
}
