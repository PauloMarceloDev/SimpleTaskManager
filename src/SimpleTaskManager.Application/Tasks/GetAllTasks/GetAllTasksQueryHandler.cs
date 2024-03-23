using PWSoftware.BaseApplication.Abstractions.Messaging;
using PWSoftware.BaseDomain.Abstractions;
using SimpleTaskManager.Domain.Tasks;

namespace SimpleTaskManager.Application.Tasks.GetAllTasks;

internal sealed class GetAllTasksQueryHandler(ITaskRepository taskRepository) 
    : IQueryHandler<GetAllTasksQuery, IEnumerable<TaskResponse>>
{
    public async Task<Result<IEnumerable<TaskResponse>>> Handle(GetAllTasksQuery _, CancellationToken cancellationToken) => 
        (await taskRepository.GetAllAsync(cancellationToken))
        .OrderByDescending(t => t.Priority)
        .Select(t => 
            new TaskResponse(
                t.Id, 
                t.Title, 
                t.Description, 
                t.Priority, 
                t.DeadlineOnUtc, 
                t.Status))
        .ToList();
}
