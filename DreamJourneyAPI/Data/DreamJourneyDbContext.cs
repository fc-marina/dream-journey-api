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

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserModel> Dreams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new DreamMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
