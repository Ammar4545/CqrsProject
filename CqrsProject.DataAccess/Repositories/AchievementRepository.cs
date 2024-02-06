using CqrsProject.DataAccess.Data;
using CqrsProject.DataAccess.Repositories.Interfaces;
using CqrsProject.Entities.Dbset;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsProject.DataAccess.Repositories
{
    public class AchievementRepository : GenericRepository<Achievement>, IAchievementRepository
    {
        public AchievementRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
        {
          
            try
            {
                return await _dbset.FirstOrDefaultAsync(a => a.DriverId == driverId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetDriverAchievementAsync function error", typeof(AchievementRepository));
                throw;
            }
        
        }

        public override async Task<IEnumerable<Achievement>> GetAll()
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
                _logger.LogError(ex, "{Repo} GetAll function error", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _dbset.FirstOrDefaultAsync(x => x.Id == id);
                if (result is null)
                    return false;

                result.UpdatedDate = DateTime.Now;
                result.Status = 0;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task<bool> Update(Achievement achievement)
        {
            try
            {
                var result = await _dbset.FirstOrDefaultAsync(x => x.Id == achievement.Id);
                if (result is null)
                    return false;

                result.UpdatedDate   = achievement.UpdatedDate;
                result.RaceWin       = achievement.RaceWin;
                result.PolePostion   = achievement.PolePostion;
                result.FastestLap    = achievement.FastestLap;
                result.WorldChampionship = achievement.WorldChampionship;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(AchievementRepository));
                throw;
            }
        }
    }
}
