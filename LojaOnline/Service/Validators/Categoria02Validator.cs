using Domain.Entities;
using FluentValidation;

namespace Services.Validators
{
    public class Categoria02Validator : AbstractValidator<Categoria02>
    {
        public Categoria02Validator()
        {
            ////EXEMPLO
            //RuleFor(c => c.Login)
            //      .NotEmpty()
            //      .WithMessage("Login não pode ser nulo.");
        }
    }
}
