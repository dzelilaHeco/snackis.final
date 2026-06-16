using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Snackis.Application.Interfaces;
using Snackis.Domain.Entities;
using Snackis.Domain.Interfaces;
using Snackis.Infrastructure.Data;

namespace Snackis.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<List<Report>> GetAllAsync()
        {
            return await _reportRepository.GetAllAsync();
        }

        public async Task<List<Report>> GetUnhandledReportsAsync()
        {
            return await _reportRepository.GetUnresolvedAsync();
        }

        public async Task HandleReportAsync(int reportId)
        {
            await _reportRepository.MarkAsHandledAsync(reportId);
        }
        public async Task CreateAsync(Report report)
        {
            await _reportRepository.AddAsync(report);
        }
    }
}
