using FootballLeague.Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballLeague.Api.Persistence.Configurations
{
    public class StandingsConfiguration : IEntityTypeConfiguration<Standings>
    {
        public void Configure(EntityTypeBuilder<Standings> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Team)
                .WithOne(x => x.Standings)
                .HasForeignKey<Standings>(x => x.TeamId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
