using DevFreela.Application.Commands.Projects.CreateComment;
using FluentValidation;

namespace DevFreela.Application.Validators.Projects
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommandInputModel>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(p => p.Content)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo de Texto de Comentário é de 255 caracteres.");
        }
    }
}
