using CqrsProject.DataAccess.Data;
using CqrsProject.DataAccess.Repositories.Interfaces;
using CqrsProject.Entities.Dbset;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CqrsProject.DataAccess.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }
        
        public override async Task<IEnumerable<Driver>> GetAll()
        {
            try
            {
                return await _dbset.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAll function error", typeof(DriverRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var result =await _dbset.FirstOrDefaultAsync(x => x.Id==id);
                if (result is null)
                    return false;

                result.UpdatedDate = DateTime.Now;
                result.Status = 0;

                return true;
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(DriverRepository));
                throw;
            }
        }

        public override async Task<bool> Update(Driver driver)
        {
            try
            {
                var result = await _dbset.FirstOrDefaultAsync(x => x.Id == driver.Id);
                if (result is null)
                    return false;

                result.UpdatedDate  = driver.UpdatedDate;
                result.DriverNumber = driver.DriverNumber;
                result.FirstName    = driver.FirstName;
                result.LastName     = driver.LastName;
                result.DateOfBirth  = driver.DateOfBirth;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(DriverRepository));
                throw;
            }
        }

    }
}
