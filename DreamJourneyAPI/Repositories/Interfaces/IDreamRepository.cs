using DreamJourneyAPI.Models;

namespace DreamJourneyAPI.Repositories.Interfaces
{
    public interface IDreamRepository
    {
        Task<List<DreamModel>> GetAll(int skip, int take);
        Task<DreamModel> GetById(int id);
        Task<DreamModel> Create(DreamModel dreamModel);
        Task<DreamModel> Update(DreamModel dreamModel, int id);
        Task<bool> Delete(int id);
    }
}
