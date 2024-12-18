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
                .WithMany()
                .HasForeignKey(x => x.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
