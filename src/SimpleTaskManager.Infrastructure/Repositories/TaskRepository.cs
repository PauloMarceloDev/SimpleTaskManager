using SimpleTaskManager.Domain.Tasks;
using Task = SimpleTaskManager.Domain.Tasks.Task;

namespace SimpleTaskManager.Infrastructure.Repositories;

public sealed class TaskRepository(ApplicationDbContext dbContext) : Repository<Task>(dbContext), ITaskRepository
{
}
