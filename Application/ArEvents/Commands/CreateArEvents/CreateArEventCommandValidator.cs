using FluentValidation;

namespace Application.ArEvents.Commands.CreateArEvents;

public class CreateArEventCommandValidator : AbstractValidator<CreateArEventCommand> {
    public CreateArEventCommandValidator() {
        RuleFor(v => v.DebtId)
            .NotEmpty().WithMessage("DebtId is required");
        
    }
}