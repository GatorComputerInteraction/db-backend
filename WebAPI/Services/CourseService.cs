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
        public Task<int> Insert(CourseModel course);
        public Task<int> Update(CourseModel course);
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
                _dbContext.Courses.Remove(
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
            return await _dbContext.Courses.ToListAsync();
        }

        public async Task<CourseModel> GetById(int id)
        {
            return await _dbContext.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
        }

        public async Task<int> Insert(CourseModel course)
        {
            _dbContext.Add(course);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(CourseModel course)
        {
            try
            {
                _dbContext.Update(course);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
