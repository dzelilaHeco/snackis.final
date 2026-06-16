using Snackis.Domain.Entities;

namespace Snackis.Application.Interfaces
{
    public interface IReportService
    {
        Task<List<Report>> GetAllAsync();
        Task<List<Report>> GetUnhandledReportsAsync();
        Task HandleReportAsync(int reportId);
        Task CreateAsync(Report report);
    }
}