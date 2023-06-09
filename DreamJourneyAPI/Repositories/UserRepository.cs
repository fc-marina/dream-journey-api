﻿using DreamJourneyAPI.Data;
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
        public async Task<List<UserModel>> GetAll(int skip, int take)
        {
            return await _dbContext.UserModel.Skip(skip).Take(take)
                .ToListAsync();
        }

        public async Task<UserModel?> GetById(int id)
        {
            return await _dbContext.UserModel.FirstOrDefaultAsync( user => user.Id == id);
        }

        public async Task<UserModel> Create(UserModel userModel)
        {
            await _dbContext.UserModel.AddAsync(userModel);
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

        public async Task<UserModel> Update(UserModel userModel, int id)
        {
            UserModel user = await GetById(id);
            if (user == null)
            {
                return user;
                //throw new Exception($"User id {id} not found");
            }

            user.Name = userModel.Name;
            user.BirthDate = userModel.BirthDate;

            _dbContext.UserModel.Update(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel user = await GetById(id);
            if (user == null)
            {
                return false;
                //throw new Exception($"User id {id} not found");
            }

            _dbContext.UserModel.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
