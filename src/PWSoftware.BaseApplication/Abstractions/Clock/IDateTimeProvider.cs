namespace PWSoftware.BaseApplication.Abstractions.Clock;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
