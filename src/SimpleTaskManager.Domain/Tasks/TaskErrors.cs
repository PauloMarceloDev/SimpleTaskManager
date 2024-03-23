using PWSoftware.BaseDomain.Abstractions;

namespace SimpleTaskManager.Domain.Tasks;

public static class TaskErrors
{
    public static readonly Error NotFound = new(
        "Task.NotFount",
        "Task not found.");
}
