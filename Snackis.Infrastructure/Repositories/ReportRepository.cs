using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Snackis.Domain.Entities;
using Snackis.Domain.Interfaces;
using Snackis.Infrastructure.Data;

namespace Snackis.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly MyDbContext _context;
        public ReportRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Report report)
        {
            report.CreatedAt = DateTime.UtcNow;

            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Report>> GetAllAsync()
        {
            return await _context.Reports
                .Include(r => r.Post)
                    .ThenInclude(p => p.User)
                .ToListAsync();
        }

        public async Task<List<Report>> GetUnresolvedAsync()
        {
            return await _context.Reports
                .Include(r => r.Post)
                    .ThenInclude(p => p.User)
                .Include(r => r.User)
                .Where(r => !r.IsHandled)
                .ToListAsync();
        }

        public async Task MarkAsHandledAsync(int reportId)
        {
            var report = await _context.Reports.FindAsync(reportId);

            if (report != null)
            {
                report.IsHandled = true;
                await _context.SaveChangesAsync();
            }
        }
        
    }
}
