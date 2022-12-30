using Snacker.Application.Common.Interfaces.Services;

namespace Snacker.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

