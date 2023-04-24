using DreamJourneyAPI.Models;

namespace DreamJourneyAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAll(int skip, int take);
        Task<UserModel> GetById(int id);
        Task<UserModel> Create(UserModel userModel);
        Task<UserModel> Update(UserModel userModel, int id);
        Task<bool> Delete(int id);
    }
}
