using SimpleTaskManager.Domain.Tasks;
using TaskStatus = SimpleTaskManager.Domain.Tasks.TaskStatus;

namespace SimpleTaskManager.Application.Tasks;

public sealed record TaskResponse(
    int Id,
    string Title,
    string Description,
    TaskPriority Priority,
    DateTime DeadlineOnUtc,
    TaskStatus Status);
