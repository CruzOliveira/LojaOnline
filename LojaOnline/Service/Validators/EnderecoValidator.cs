using Domain.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            ////EXEMPLO
            //RuleFor(c => c.Login)
            //      .NotEmpty()
            //      .WithMessage("Login não pode ser nulo.");
        }
    }
}
