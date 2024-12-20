using FootballLeague.Api.Entities;

namespace FootballLeague.Tests.Entities
{
    public class MatchTests
    {
        [Fact]
        public void Constructor_ShouldInitializeMatchCorrectly()
        {
            // Arrange
            var homeTeamId = 1;
            var awayTeamId = 2;
            var homeTeamScore = 3;
            var awayTeamScore = 2;

            // Act
            var match = new Match(homeTeamId, awayTeamId, homeTeamScore, awayTeamScore);

            // Assert
            match.MatchDate.Should().BeCloseTo(DateTime.UtcNow, precision: TimeSpan.FromSeconds(1));
            match.HomeTeamId.Should().Be(homeTeamId);
            match.AwayTeamId.Should().Be(awayTeamId);
            match.HomeTeamScore.Should().Be(homeTeamScore);
            match.AwayTeamScore.Should().Be(awayTeamScore);
        }

        [Fact]
        public void UpdateHomeTeamScore_ShouldUpdateScoreCorrectly()
        {
            // Arrange
            var match = new Match(1, 2, 3, 2);
            var newHomeTeamScore = 5;

            // Act
            match.UpdateHomeTeamScore(newHomeTeamScore);

            // Assert
            match.HomeTeamScore.Should().Be(newHomeTeamScore);
        }

        [Fact]
        public void UpdateAwayTeamScore_ShouldUpdateScoreCorrectly()
        {
            // Arrange
            var match = new Match(1, 2, 3, 2);
            var newAwayTeamScore = 4;

            // Act
            match.UpdateAwayTeamScore(newAwayTeamScore);

            // Assert
            match.AwayTeamScore.Should().Be(newAwayTeamScore);
        }

        [Fact]
        public void UpdateHomeTeamScore_ShouldReturnMatchInstance()
        {
            // Arrange
            var match = new Match(1, 2, 3, 2);
            var newHomeTeamScore = 5;

            // Act
            var updatedMatch = match.UpdateHomeTeamScore(newHomeTeamScore);

            // Assert
            updatedMatch.Should().Be(match);
        }

        [Fact]
        public void UpdateAwayTeamScore_ShouldReturnMatchInstance()
        {
            // Arrange
            var match = new Match(1, 2, 3, 2);
            var newAwayTeamScore = 4;

            // Act
            var updatedMatch = match.UpdateAwayTeamScore(newAwayTeamScore);

            // Assert
            updatedMatch.Should().Be(match);
        }
    }
}
