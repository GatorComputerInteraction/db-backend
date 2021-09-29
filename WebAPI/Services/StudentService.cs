using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DbContexts;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IStudentService
    {
        public Task<int> Delete(int id);
        public Task<IEnumerable<StudentModel>> GetAll();
        public Task<StudentModel> GetById(int id);
        public Task<int> Insert(StudentModel student);
        public Task<int> Update(StudentModel student);
    }

    public sealed class StudentService : IStudentService
    {
        private readonly MariaDbContext _dbContext;

        public StudentService(MariaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                _dbContext.Students.Remove(
                    new StudentModel
                    {
                        UfId = id
                    }
                );

                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<StudentModel>> GetAll()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<StudentModel> GetById(int id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(x => x.UfId == id);
        }

        public async Task<int> Insert(StudentModel student)
        {
            _dbContext.Add(student);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(StudentModel student)
        {
            try
            {
                _dbContext.Update(student);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
