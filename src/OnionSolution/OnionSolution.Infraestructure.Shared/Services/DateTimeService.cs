using OnionSolution.Core.Application.Interfaces;

namespace OnionSolution.Infraestructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
