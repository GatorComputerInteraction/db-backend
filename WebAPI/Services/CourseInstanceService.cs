using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ICourseInstanceService
    {
        public Task<int> Delete(int id);
        public Task<IEnumerable<CourseInstanceModel>> GetAll();
        public Task<CourseInstanceModel> GetById(int id);
        public Task<IEnumerable<CourseInstanceModel>> GetBySemesterYear(string semester, int year);
        public Task<int> Insert(CourseInstanceModel courseInstance);
        public Task<int> Update(CourseInstanceModel courseInstance);
    }

    public sealed class CourseInstanceService : ICourseInstanceService
    {
        private readonly DbContexts.NpgDbContext _dbContext;

        public CourseInstanceService(DbContexts.NpgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                _dbContext.CourseInstance.Remove(
                    new CourseInstanceModel
                    {
                        InstanceId = id
                    }
                );

                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<CourseInstanceModel>> GetAll()
        {
            return await _dbContext.CourseInstance.ToListAsync();
        }

        public async Task<CourseInstanceModel> GetById(int id)
        {
            return await _dbContext.CourseInstance.FirstOrDefaultAsync(x => x.InstanceId == id);
        }

        public async Task<IEnumerable<CourseInstanceModel>> GetBySemesterYear(string semester, int year)
        {
            return (await _dbContext.CourseInstance.ToListAsync()).Where(x => x.Semester == semester && x.Year == year);
        }

        public async Task<int> Insert(CourseInstanceModel courseInstance)
        {
            _dbContext.Add(courseInstance);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(CourseInstanceModel courseInstance)
        {
            try
            {
                _dbContext.Update(courseInstance);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
