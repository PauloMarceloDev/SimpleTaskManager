using PWSoftware.BaseApplication.Abstractions.Messaging;
using PWSoftware.BaseDomain.Abstractions;
using SimpleTaskManager.Domain.Tasks;
using Task = SimpleTaskManager.Domain.Tasks.Task;

namespace SimpleTaskManager.Application.Tasks.GetTaskById;

internal sealed class GetTaskByIdQueryHandler(ITaskRepository taskRepository) 
    : IQueryHandler<GetTaskByIdQuery, TaskResponse>
{
    public async Task<Result<TaskResponse>> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        Task? task =  await taskRepository.GetByIdOrDefaultAsync(request.Id, cancellationToken);

        if (task is null)
        {
            return Result.Failure<TaskResponse>(TaskErrors.NotFound);
        }
        
        return new TaskResponse(
            task.Id,
            task.Title,
            task.Description,
            task.Priority,
            task.DeadlineOnUtc,
            task.Status);
    }
}
