using TechLibrary.Communication.Requests;
using FluentValidation;

namespace TechLibrary.Api.UseCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("Nome Obrigatorio");
            RuleFor(request => request.Email).EmailAddress().WithMessage("o Email nao e valido");
            RuleFor(request => request.Password).NotEmpty().WithMessage("a Senha e obrigatoria");
            When(request => string.IsNullOrEmpty(request.Password) == false, () =>
            {
                RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(6).WithMessage("a Senha deve conter mais que 6 caracteres");
            });
        }
    }

    
}
