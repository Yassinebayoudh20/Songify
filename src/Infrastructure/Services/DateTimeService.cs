using projects.Application.Common.Interfaces;

namespace projects.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
