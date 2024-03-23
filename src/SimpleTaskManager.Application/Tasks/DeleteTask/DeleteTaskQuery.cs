using PWSoftware.BaseApplication.Abstractions.Messaging;
using Task = SimpleTaskManager.Domain.Tasks.Task;

namespace SimpleTaskManager.Application.Tasks.DeleteTask;

public sealed record DeleteTaskCommand(int Id) : ICommand;
