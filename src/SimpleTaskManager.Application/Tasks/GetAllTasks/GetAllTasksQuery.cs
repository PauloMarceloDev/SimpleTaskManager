using PWSoftware.BaseApplication.Abstractions.Messaging;

namespace SimpleTaskManager.Application.Tasks.GetAllTasks;

public sealed record GetAllTasksQuery() : IQuery<IEnumerable<TaskResponse>>;
