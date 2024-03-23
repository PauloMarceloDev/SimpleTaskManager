using SimpleTaskManager.Domain.Tasks;
using TaskStatus = SimpleTaskManager.Domain.Tasks.TaskStatus;

namespace SimpleTaskManager.Api.Controllers.Tasks;

public sealed record UpdateTaskRequest(
    string Title,
    string Description,
    TaskPriority Priority,
    DateTime DeadlineOnUtc,
    TaskStatus Status);
