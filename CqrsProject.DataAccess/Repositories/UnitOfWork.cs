using CqrsProject.DataAccess.Data;
using CqrsProject.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsProject.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public IDriverRepository Drivers { get; private set; }
        public IAchievementRepository Achievements { get; private set; }

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Logs");
            Drivers = new DriverRepository(_context, _logger);
            Achievements = new AchievementRepository(_context, _logger);
        }

        public async Task<bool> CompleteAsync()
        {
            var result=await _context.SaveChangesAsync();
            return result > 0;
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
