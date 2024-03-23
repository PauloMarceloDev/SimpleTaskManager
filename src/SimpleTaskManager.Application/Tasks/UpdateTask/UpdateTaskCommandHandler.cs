using PWSoftware.BaseApplication.Abstractions.Messaging;
using PWSoftware.BaseDomain.Abstractions;
using SimpleTaskManager.Domain.Tasks;
using Task = SimpleTaskManager.Domain.Tasks.Task;

namespace SimpleTaskManager.Application.Tasks.UpdateTask;

internal sealed class UpdateTaskCommandHandler(
    ITaskRepository taskRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateTaskCommand>
{
    public async Task<Result> Handle(
        UpdateTaskCommand request,
        CancellationToken cancellationToken)
    {
        Task? entity =  await taskRepository.GetByIdOrDefaultAsync(request.TaskId, cancellationToken);

        if (entity is null)
        {
            return Result.Failure<TaskResponse>(TaskErrors.NotFound);
        }
        
        entity.Update(request.Title, request.Description, request.Priority, request.DeadlineOnUtc, request.Status);
        
        taskRepository.Update(entity);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
