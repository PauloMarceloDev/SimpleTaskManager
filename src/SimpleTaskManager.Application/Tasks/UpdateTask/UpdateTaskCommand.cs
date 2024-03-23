using PWSoftware.BaseApplication.Abstractions.Messaging;
using SimpleTaskManager.Domain.Tasks;
using TaskStatus = SimpleTaskManager.Domain.Tasks.TaskStatus;

namespace SimpleTaskManager.Application.Tasks.UpdateTask;

public sealed record UpdateTaskCommand(
    int TaskId,
    string Title,
    string Description,
    TaskPriority Priority,
    DateTime DeadlineOnUtc,
    TaskStatus Status) : ICommand;
