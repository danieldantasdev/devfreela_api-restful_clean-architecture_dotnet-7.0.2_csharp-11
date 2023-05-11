using System.Text.RegularExpressions;
using DevFreela.Application.Commands.Users.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators.Users;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(p => p.Email).EmailAddress().WithMessage("E-mail não válido!");

        RuleFor(p => p.Password).Must(ValidPassword).WithMessage(
            "Senha deve conter pelo menos 8 caracteres, um número, uma letra minúscula, uma letra maiúscula e um caracter especial");

        RuleFor(p => p.FullName).NotEmpty().NotNull().WithMessage("Nome é obrigatório!");
    }

    private bool ValidPassword(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}