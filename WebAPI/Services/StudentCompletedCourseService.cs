using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DbContexts;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IStudentCompletedCourseService
    {
        public Task<int> Delete(int id1, int id2);
        public Task<IEnumerable<StudentCompletedCourseModel>> GetAll();
        public Task<StudentCompletedCourseModel> GetById(int id1, int id2);
        public Task<int> Insert(StudentCompletedCourseModel studentCompletedCourse);
        public Task<int> Update(StudentCompletedCourseModel studentCompletedCourse);
    }

    public sealed class StudentCompletedCourseService : IStudentCompletedCourseService
    {
        private readonly DbContexts.NpgDbContext _dbContext;

        public StudentCompletedCourseService(DbContexts.NpgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(int id1, int id2)
        {
            try
            {
                _dbContext.StudentCompletedCourses.Remove(
                    new StudentCompletedCourseModel
                    {
                        UfId = id1,
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

        public async Task<IEnumerable<StudentCompletedCourseModel>> GetAll()
        {
            return await _dbContext.StudentCompletedCourses.ToListAsync();
        }

        public async Task<StudentCompletedCourseModel> GetById(int id1, int id2)
        {
            return await _dbContext.StudentCompletedCourses.FirstOrDefaultAsync(x => x.UfId == id1 && x.CourseId == id2);
        }

        public async Task<int> Insert(StudentCompletedCourseModel studentCompletedCourse)
        {
            _dbContext.Add(studentCompletedCourse);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(StudentCompletedCourseModel studentCompletedCourse)
        {
            try
            {
                _dbContext.Update(studentCompletedCourse);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
