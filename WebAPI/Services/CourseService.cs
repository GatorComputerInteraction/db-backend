using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DbContexts;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ICourseService
    {
        public Task<int> Delete(int id);
        public Task<IEnumerable<CourseModel>> GetAll();
        public Task<CourseModel> GetById(int id);
        public Task<int> Insert(CourseModel Course);
        public Task<int> Update(CourseModel Course);
    }

    public sealed class CourseService : ICourseService
    {
        private readonly DbContexts.NpgDbContext _dbContext;

        public CourseService(DbContexts.NpgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                _dbContext.Course.Remove(
                    new CourseModel
                    {
                        CourseId = id
                    }
                );

                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<CourseModel>> GetAll()
        {
            return await _dbContext.Course.ToListAsync();
        }

        public async Task<CourseModel> GetById(int id)
        {
            return await _dbContext.Course.FirstOrDefaultAsync(x => x.CourseId == id);
        }

        public async Task<int> Insert(CourseModel Course)
        {
            _dbContext.Add(Course);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(CourseModel Course)
        {
            try
            {
                _dbContext.Update(Course);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
