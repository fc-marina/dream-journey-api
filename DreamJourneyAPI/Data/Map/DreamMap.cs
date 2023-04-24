using DreamJourneyAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DreamJourneyAPI.Data.Map
{
    public class DreamMap : IEntityTypeConfiguration<DreamModel>
    {
        public void Configure(EntityTypeBuilder<DreamModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.LifeArea);
            builder.Property(x => x.Status);
        }
    }
}
