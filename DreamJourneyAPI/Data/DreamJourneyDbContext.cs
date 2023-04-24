using Microsoft.EntityFrameworkCore;
using DreamJourneyAPI.Models;
using DreamJourneyAPI.Data.Map;

namespace DreamJourneyAPI.Data
{
    public class DreamJourneyDbContext : DbContext
    {
        public DreamJourneyDbContext(DbContextOptions<DreamJourneyDbContext> options) 
            : base(options)
        {

        }

        public DbSet<UserModel> UserModel { get; set; }
        public DbSet<DreamModel> DreamModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new DreamMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
