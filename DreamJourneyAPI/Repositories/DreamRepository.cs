using DreamJourneyAPI.Data;
using DreamJourneyAPI.Models;
using DreamJourneyAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DreamJourneyAPI.Repositories
{
    public class DreamRepository : IDreamRepository
    {
        private readonly DreamJourneyDbContext _dbContext;

        public DreamRepository(DreamJourneyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DreamModel>> GetAll()
        {
            return await _dbContext.DreamModel.ToListAsync();
        }

        public async Task<DreamModel> GetById(int id)
        {
            return await _dbContext.DreamModel.FirstOrDefaultAsync(dream => dream.Id == id);
        }

        public async Task<DreamModel> Create(DreamModel dreamModel)
        {
            await _dbContext.DreamModel.AddAsync(dreamModel);
            await _dbContext.SaveChangesAsync();
            return dreamModel;
        }

        public async Task<DreamModel> Update(DreamModel dreamModel, int id)
        {
            DreamModel dream = await GetById(id);
            if (dream == null)
            {
                throw new Exception($"Dream id {id} not found");
            }

            dream.Name = dreamModel.Name;
            dream.Description = dreamModel.Description;
            dream.LifeArea = dreamModel.LifeArea;
            dream.Status = dreamModel.Status;
            dream.UserId = dreamModel.UserId;

            _dbContext.DreamModel.Update(dream);
            await _dbContext.SaveChangesAsync();

            return dream;
        }

        public async Task<bool> Delete(int id)
        {
            DreamModel dream = await GetById(id);
            if (dream == null)
            {
                throw new Exception($"Dream id {id} not found");
            }

            _dbContext.DreamModel.Remove(dream);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
