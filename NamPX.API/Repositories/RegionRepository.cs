using Microsoft.EntityFrameworkCore;
using NamPX.API.Data;
using NamPX.API.Models.Domain;

namespace NamPX.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {

        private readonly DBContext dBContext;

        public RegionRepository(DBContext dBContext) { 
            this.dBContext = dBContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await dBContext.AddAsync(region);
            await dBContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(region == null)
            {
                return null;
            }

            // Delete region
            dBContext.Regions.Remove(region);
            await dBContext.SaveChangesAsync();

            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync(){
            return await dBContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await dBContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
