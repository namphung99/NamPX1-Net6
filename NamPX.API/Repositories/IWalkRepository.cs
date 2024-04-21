using NamPX.API.Models.Domain;

namespace NamPX.API.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();

        Task<Walk> GetAsync(Guid id);
    }
}
