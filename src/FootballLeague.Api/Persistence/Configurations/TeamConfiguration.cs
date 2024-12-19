using FootballLeague.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FootballLeague.Api.AppConstants;

namespace FootballLeague.Api.Persistence.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(TeamNameMaxLenght).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
