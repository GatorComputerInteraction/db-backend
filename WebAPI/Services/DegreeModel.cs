using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DbContexts;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IDegreeService
    {
        public Task<int> Delete(int id);
        public Task<IEnumerable<DegreeModel>> GetAll();
        public Task<DegreeModel> GetById(int id);
        public Task<int> Insert(DegreeModel degree);
        public Task<int> Update(DegreeModel degree);
    }

    public sealed class DegreeService : IDegreeService
    {
        private readonly DbContexts.NpgDbContext _dbContext;

        public DegreeService(DbContexts.NpgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                _dbContext.Degrees.Remove(
                    new DegreeModel
                    {
                        DegreeId = id
                    }
                );

                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<DegreeModel>> GetAll()
        {
            return await _dbContext.Degrees.ToListAsync();
        }

        public async Task<DegreeModel> GetById(int id)
        {
            return await _dbContext.Degrees.FirstOrDefaultAsync(x => x.DegreeId == id);
        }

        public async Task<int> Insert(DegreeModel degree)
        {
            _dbContext.Add(degree);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(DegreeModel degree)
        {
            try
            {
                _dbContext.Update(degree);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
