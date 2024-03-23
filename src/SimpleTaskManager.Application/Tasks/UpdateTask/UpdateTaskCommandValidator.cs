using FluentValidation;

namespace SimpleTaskManager.Application.Tasks.UpdateTask;

public sealed class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(c => c.TaskId)
            .NotEmpty()
            .GreaterThanOrEqualTo(1);
        
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
        
        RuleFor(c => c.Status)
            .NotEmpty()
            .IsInEnum();
    }
}
