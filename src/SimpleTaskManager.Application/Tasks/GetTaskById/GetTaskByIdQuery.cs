using PWSoftware.BaseApplication.Abstractions.Messaging;
using Task = SimpleTaskManager.Domain.Tasks.Task;

namespace SimpleTaskManager.Application.Tasks.GetTaskById;

public sealed record GetTaskByIdQuery(int Id) : IQuery<TaskResponse>;
