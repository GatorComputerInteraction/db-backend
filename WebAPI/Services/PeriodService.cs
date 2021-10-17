using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DbContexts;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IPeriodService
    {
        public Task<int> Delete(int id);
        public Task<IEnumerable<PeriodModel>> GetAll();
        public Task<PeriodModel> GetById(int id);
        public Task<int> Insert(PeriodModel period);
        public Task<int> Update(PeriodModel period);
    }

    public sealed class PeriodService : IPeriodService
    {
        private readonly DbContexts.NpgDbContext _dbContext;

        public PeriodService(DbContexts.NpgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                _dbContext.Period.Remove(
                    new PeriodModel
                    {
                        PeriodId = id
                    }
                );

                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<PeriodModel>> GetAll()
        {
            return await _dbContext.Period.ToListAsync();
        }

        public async Task<PeriodModel> GetById(int id)
        {
            return await _dbContext.Period.FirstOrDefaultAsync(x => x.PeriodId == id);
        }

        public async Task<int> Insert(PeriodModel period)
        {
            _dbContext.Add(period);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(PeriodModel period)
        {
            try
            {
                _dbContext.Update(period);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
