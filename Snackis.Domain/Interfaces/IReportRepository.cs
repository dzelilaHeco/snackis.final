using Snackis.Domain.Entities;

namespace Snackis.Domain.Interfaces
{
    public interface IReportRepository
    {
        Task AddAsync(Report report);
        Task<List<Report>> GetAllAsync();
        Task<List<Report>> GetUnresolvedAsync();
        Task MarkAsHandledAsync(int reportId);
    }
}