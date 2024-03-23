using PWSoftware.BaseApplication.Abstractions.Messaging;
using PWSoftware.BaseDomain.Abstractions;
using SimpleTaskManager.Domain.Tasks;
using Task = SimpleTaskManager.Domain.Tasks.Task;

namespace SimpleTaskManager.Application.Tasks.DeleteTask;

internal sealed class DeleteTaskCommandHandler(
    ITaskRepository taskRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<DeleteTaskCommand>
{
    public async Task<Result> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        Task? task =  await taskRepository.GetByIdOrDefaultAsync(request.Id, cancellationToken);

        if (task is null)
        {
            return Result.Failure<TaskResponse>(TaskErrors.NotFound);
        }
        
        taskRepository.Delete(task);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
