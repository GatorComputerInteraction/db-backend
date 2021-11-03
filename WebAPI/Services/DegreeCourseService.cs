using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IDegreeCourseService
    {
        public Task<int> Delete(int id1, int id2);
        public Task<IEnumerable<DegreeCourseModel>> GetAll();
        public Task<IEnumerable<DegreeCourseModel>> GetByDegreeId(int degreeId);
        public Task<IEnumerable<DegreeCourseModel>> GetByCourseId(int courseId);
        public Task<IEnumerable<DegreeCourseModel>> GetByRequirementType(int requirementType);
        public Task<IEnumerable<DegreeCourseModel>> GetByDegreeIdAndRequirementType(int degreeId, int requirementType);
        public Task<IEnumerable<DegreeCourseModel>> GetByCourseIdAndRequirementType(int courseId, int requirementType);
        public Task<DegreeCourseModel> GetByIds(int degreeId, int courseId);
        public Task<DegreeCourseModel> GetByAllParams(int degreeId, int courseId, int requirementType);
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

        public async Task<IEnumerable<DegreeCourseModel>> GetByDegreeId(int degreeId)
        {
            return (await _dbContext.DegreeCourses.ToListAsync()).Where(ele => ele.DegreeId == degreeId);
        }

        public async Task<IEnumerable<DegreeCourseModel>> GetByCourseId(int courseId)
        {
            return (await _dbContext.DegreeCourses.ToListAsync()).Where(ele => ele.CourseId == courseId);
        }

        public async Task<IEnumerable<DegreeCourseModel>> GetByRequirementType(int requirementType)
        {
            return (await _dbContext.DegreeCourses.ToListAsync()).Where(ele => ele.RequirementType == requirementType);
        }

        public async Task<IEnumerable<DegreeCourseModel>> GetByDegreeIdAndRequirementType(int degreeId, int requirementType)
        {
            return (await _dbContext.DegreeCourses.ToListAsync()).Where(ele => ele.DegreeId == degreeId && ele.RequirementType == requirementType);
        }

        public async Task<IEnumerable<DegreeCourseModel>> GetByCourseIdAndRequirementType(int courseId, int requirementType)
        {
            return (await _dbContext.DegreeCourses.ToListAsync()).Where(ele => ele.CourseId == courseId && ele.RequirementType == requirementType);
        }

        public async Task<DegreeCourseModel> GetByIds(int degreeId, int courseId)
        {
            return await _dbContext.DegreeCourses.FirstOrDefaultAsync(x => x.DegreeId == degreeId && x.CourseId == courseId);
        }

        public async Task<DegreeCourseModel> GetByAllParams(int degreeId, int courseId, int requirementType)
        {
            return await _dbContext.DegreeCourses.FirstOrDefaultAsync(x => x.DegreeId == degreeId && x.CourseId == courseId && x.RequirementType == requirementType);
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
