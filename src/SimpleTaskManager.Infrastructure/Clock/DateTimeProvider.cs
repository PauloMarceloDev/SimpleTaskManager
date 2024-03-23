using PWSoftware.BaseApplication.Abstractions.Clock;

namespace SimpleTaskManager.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
