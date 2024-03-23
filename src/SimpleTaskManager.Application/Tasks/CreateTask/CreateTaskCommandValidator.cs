using FluentValidation;

namespace SimpleTaskManager.Application.Tasks.CreateTask;

public sealed class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(c => c.Title)
            .MinimumLength(3)
            .MaximumLength(255);
        
        RuleFor(c => c.Description)
            .MinimumLength(3)
            .MaximumLength(2048);
        
        RuleFor(c => c.Priority)
            .IsInEnum();
        
        RuleFor(c => c.DeadlineOnUtc)
            .NotEmpty();
    }
}
