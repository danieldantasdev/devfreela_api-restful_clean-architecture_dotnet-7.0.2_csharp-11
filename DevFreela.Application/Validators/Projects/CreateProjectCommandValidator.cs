using DevFreela.Application.Commands.Projects.CreateProject;
using FluentValidation;

namespace DevFreela.Application.Validators.Projects;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommandInputModel>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(p => p.Description)
            .MaximumLength(255)
            .WithMessage("Tamanho máximo de Descrição é de 255 caracteres.");
        
        RuleFor(p => p.Title)
            .MaximumLength(30)
            .WithMessage("Tamanho máximo de Descrição é de 30 caracteres.");
    }
}