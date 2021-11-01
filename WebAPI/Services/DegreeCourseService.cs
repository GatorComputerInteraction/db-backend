using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DbContexts;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IDegreeCourseService
    {
        public Task<int> Delete(int id1, int id2);
        public Task<IEnumerable<DegreeCourseModel>> GetAll();
        public Task<DegreeCourseModel> GetById(int id1, int id2);
        public Task<int> Insert(DegreeCourseModel degreeCourse);
        public Task<int> Update(DegreeCourseModel degreeCourse);
    }

    public sealed class DegreeCourseService : IDegreeCourseService
    {
        private readonly DbContexts.NpgDbContext _dbContext;

        public DegreeCourseService(DbContexts.NpgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(int id1, int id2)
        {
            try
            {
                _dbContext.DegreeCourses.Remove(
                    new DegreeCourseModel
                    {
                        DegreeId = id1,
                        CourseId = id2
                    }
                );

                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<DegreeCourseModel>> GetAll()
        {
            return await _dbContext.DegreeCourses.ToListAsync();
        }

        public async Task<DegreeCourseModel> GetById(int id1, int id2)
        {
            return await _dbContext.DegreeCourses.FirstOrDefaultAsync(x => x.DegreeId == id1 && x.CourseId == id2);
        }

        public async Task<int> Insert(DegreeCourseModel degreeCourse)
        {
            _dbContext.Add(degreeCourse);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(DegreeCourseModel degreeCourse)
        {
            try
            {
                _dbContext.Update(degreeCourse);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
