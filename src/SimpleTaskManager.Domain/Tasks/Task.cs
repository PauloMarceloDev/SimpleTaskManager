using PWSoftware.BaseDomain.Abstractions;

namespace SimpleTaskManager.Domain.Tasks;

public sealed class Task : Entity
{
    private Task(
        string title,
        string description,
        TaskPriority priority,
        DateTime deadlineOnUtc,
        TaskStatus status)
    {
        Title = title;
        Description = description;
        Priority = priority;
        DeadlineOnUtc = deadlineOnUtc;
        Status = status;
    }

    private Task()
    {
    }
    
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TaskPriority Priority { get; private set; }
    public DateTime DeadlineOnUtc { get; private set; }
    public TaskStatus Status { get; private set; }

    public static Task Create(
        string title,
        string description,
        TaskPriority priority,
        DateTime deadlineOnUtc)
    {
        var task = new Task(
            title,
            description,
            priority,
            deadlineOnUtc,
            TaskStatus.Pending);
        
        return task;
    }

    public void Update(
        string title,
        string description,
        TaskPriority priority,
        DateTime deadlineOnUtc,
        TaskStatus status)
    {
        Title = title;
        Description = description;
        Priority = priority;
        DeadlineOnUtc = deadlineOnUtc;
        Status = status;
    }
}
