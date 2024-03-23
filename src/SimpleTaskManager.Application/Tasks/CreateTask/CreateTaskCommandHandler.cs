using PWSoftware.BaseApplication.Abstractions.Messaging;
using PWSoftware.BaseDomain.Abstractions;
using SimpleTaskManager.Domain.Tasks;
using Task = SimpleTaskManager.Domain.Tasks.Task;

namespace SimpleTaskManager.Application.Tasks.CreateTask;

internal sealed class CreateTaskCommandHandler(
    ITaskRepository taskRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateTaskCommand, TaskResponse>
{
    public async Task<Result<TaskResponse>> Handle(
        CreateTaskCommand request,
        CancellationToken cancellationToken)
    {
        var task = Task.Create(
            request.Title, 
            request.Description, 
            request.Priority, 
            request.DeadlineOnUtc);

        taskRepository.Add(task);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new TaskResponse(
            task.Id, 
            task.Title, 
            task.Description, 
            task.Priority, 
            task.DeadlineOnUtc, 
            task.Status);
    }
}
