using SimpleTaskManager.Domain.Tasks;

namespace SimpleTaskManager.Api.Controllers.Tasks;

public sealed record CreateTaskRequest(
    string Title,
    string Description,
    TaskPriority Priority,
    DateTime DeadlineOnUtc);
