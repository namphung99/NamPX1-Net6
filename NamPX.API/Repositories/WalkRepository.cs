using Microsoft.EntityFrameworkCore;
using NamPX.API.Data;
using NamPX.API.Models.Domain;

namespace NamPX.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly DBContext dBContext;

        public WalkRepository(DBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await dBContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await dBContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
