using FootballLeague.Api.Entities;
using FootballLeague.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Tests
{
    public static class TestDatabaseHelper
    {
        public static DbContextOptions<AppDbContext> CreateInMemoryDatabaseOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        public static async Task<AppDbContext> InitializeDatabaseWithTeamAsync(string teamName)
        {
            var options = CreateInMemoryDatabaseOptions($"TestDatabase_{teamName}");
            var context = new AppDbContext(options);

            var team = new Team(teamName);
            context.Teams.Add(team);
            await context.SaveChangesAsync();

            return context;
        }

        public static async Task<AppDbContext> InitializeDatabaseWithTeamAndStandingsAsync(string teamName)
        {
            var context = await InitializeDatabaseWithTeamAsync(teamName);

            var team = await context.Teams.FirstAsync();
            var standings = new Standings(team.Id);
            context.Standings.Add(standings);
            await context.SaveChangesAsync();

            return context;
        }
    }
}
