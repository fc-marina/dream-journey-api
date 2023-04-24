using DreamJourneyAPI.Data;
using DreamJourneyAPI.Models;
using DreamJourneyAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DreamJourneyAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DreamJourneyDbContext _dbContext;
        public UserRepository(DreamJourneyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync( user => user.Id == id);
        }

        public async Task<UserModel> Create(UserModel userModel)
        {
            await _dbContext.Users.AddAsync(userModel);
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

        public async Task<UserModel> Update(UserModel userModel, int id)
        {
            UserModel user = await GetById(id);
            if (user == null)
            {
                throw new Exception($"User id {id} not found");
            }

            user.Name = userModel.Name;
            user.BirthDate = userModel.BirthDate;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;

        }

        public async Task<bool> Delete(int id)
        {
            UserModel user = await GetById(id);
            if (user == null)
            {
                throw new Exception($"User id {id} not found");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
