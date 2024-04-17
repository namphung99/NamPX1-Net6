using Microsoft.EntityFrameworkCore;
using NamPX.API.Models.Domain;

namespace NamPX.API.Data
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options): base(options) {
            
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
    }
}
