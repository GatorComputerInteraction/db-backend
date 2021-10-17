using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DbContexts;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ITimeslotService
    {
        public Task<int> Delete(int id);
        public Task<IEnumerable<TimeslotModel>> GetAll();
        public Task<TimeslotModel> GetById(int id);
        public Task<int> Insert(TimeslotModel timeslot);
        public Task<int> Update(TimeslotModel timeslot);
    }

    public sealed class TimeslotService : ITimeslotService
    {
        private readonly DbContexts.NpgDbContext _dbContext;

        public TimeslotService(DbContexts.NpgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                _dbContext.Timeslot.Remove(
                    new TimeslotModel
                    {
                        SlotId = id
                    }
                );

                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<TimeslotModel>> GetAll()
        {
            return await _dbContext.Timeslot.ToListAsync();
        }

        public async Task<TimeslotModel> GetById(int id)
        {
            return await _dbContext.Timeslot.FirstOrDefaultAsync(x => x.SlotId == id);
        }

        public async Task<int> Insert(TimeslotModel timeslot)
        {
            _dbContext.Add(timeslot);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(TimeslotModel timeslot)
        {
            try
            {
                _dbContext.Update(timeslot);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
