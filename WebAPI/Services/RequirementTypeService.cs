using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DbContexts;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IRequirementTypeService
    {
        public Task<int> Delete(int type);
        public Task<IEnumerable<RequirementTypeModel>> GetAll();
        public Task<RequirementTypeModel> GetByType(int type);
        public Task<int> Insert(RequirementTypeModel RequirementType);
        public Task<int> Update(RequirementTypeModel RequirementType);
    }

    public sealed class RequirementTypeService : IRequirementTypeService
    {
        private readonly DbContexts.NpgDbContext _dbContext;

        public RequirementTypeService(DbContexts.NpgDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Delete(int type)
        {
            try
            {
                _dbContext.RequirementType.Remove(
                    new RequirementTypeModel
                    {
                        RequirementType = type
                    }
                );

                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }

        public async Task<IEnumerable<RequirementTypeModel>> GetAll()
        {
            return await _dbContext.RequirementType.ToListAsync();
        }

        public async Task<RequirementTypeModel> GetByType(int type)
        {
            return await _dbContext.RequirementType.FirstOrDefaultAsync(x => x.RequirementType == type);
        }

        public async Task<int> Insert(RequirementTypeModel RequirementType)
        {
            _dbContext.Add(RequirementType);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(RequirementTypeModel RequirementType)
        {
            try
            {
                _dbContext.Update(RequirementType);
                return await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return 0;
            }
        }
    }
}
