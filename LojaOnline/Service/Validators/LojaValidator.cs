using Domain.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class LojaValidator : AbstractValidator<Loja>
    {
        public LojaValidator()
        {
            ////EXEMPLO
            //RuleFor(c => c.Login)
            //      .NotEmpty()
            //      .WithMessage("Login n�o pode ser nulo.");
        }
    }
}
