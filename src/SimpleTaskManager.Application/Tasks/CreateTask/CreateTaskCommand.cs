using PWSoftware.BaseApplication.Abstractions.Messaging;
using SimpleTaskManager.Domain.Tasks;

namespace SimpleTaskManager.Application.Tasks.CreateTask;

public sealed record CreateTaskCommand(
    string Title,
    string Description,
    TaskPriority Priority,
    DateTime DeadlineOnUtc) : ICommand<TaskResponse>;
