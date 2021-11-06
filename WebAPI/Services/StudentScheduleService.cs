using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IStudentScheduleService
    {
        public Task<int> Delete(int id1, int id2);
        public Task<IEnumerable<StudentScheduleModel>> GetAll();
        public Task<IEnumerable<StudentScheduleModel>> GetById(int ufId);
        public Task<StudentScheduleModel> GetByIds(int id1, int id2);
        public Task<int> Insert(StudentScheduleModel studentSchedule);
        public Task<int> Update(StudentScheduleModel studentSchedule);
    }

    public sealed class StudentScheduleService : IStudentScheduleService
    {
        private readonly DbContexts.NpgDbContext _dbContext;

        public StudentScheduleService(DbContexts.NpgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(int id1, int id2)
        {
            try
            {
                _dbContext.StudentSchedule.Remove(
                    new StudentScheduleModel
                    {
                        UfId = id1,
                        InstanceId = id2
                    }
                );

                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<StudentScheduleModel>> GetAll()
        {
            return await _dbContext.StudentSchedule.ToListAsync();
        }

        public async Task<IEnumerable<StudentScheduleModel>> GetById(int ufId)
        {
            return (await _dbContext.StudentSchedule.ToListAsync()).Where(x => x.UfId == ufId);
        }

        public async Task<StudentScheduleModel> GetByIds(int id1, int id2)
        {
            return await _dbContext.StudentSchedule.FirstOrDefaultAsync(x => x.UfId == id1 && x.InstanceId == id2);
        }

        public async Task<int> Insert(StudentScheduleModel studentSchedule)
        {
            try
            {
                _dbContext.Add(studentSchedule);
                return await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return -1;
            }
        }

        public async Task<int> Update(StudentScheduleModel studentSchedule)
        {
            try
            {
                _dbContext.Update(studentSchedule);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
