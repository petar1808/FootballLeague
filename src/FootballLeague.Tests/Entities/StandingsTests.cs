using FootballLeague.Api.Entities;

namespace FootballLeague.Tests.Entities
{
    public class StandingsTests
    {
        [Fact]
        public void AddRecord_ShouldIncreaseMatchesPlayedAndGoals_WhenTeamWins()
        {
            // Arrange
            var standings = new Standings(1);

            // Act
            standings.AddRecord(2, 1);

            // Assert
            standings.MatchesPlayed.Should().Be(1);
            standings.Wins.Should().Be(1);
            standings.GoalsScored.Should().Be(2);
            standings.GoalsConceded.Should().Be(1);
            standings.Points.Should().Be(3);
        }

        [Fact]
        public void AddRecord_ShouldIncreaseMatchesPlayedAndGoals_WhenTeamLoses()
        {
            // Arrange
            var standings = new Standings(1);

            // Act
            standings.AddRecord(1, 2);

            // Assert
            standings.MatchesPlayed.Should().Be(1);
            standings.Losses.Should().Be(1);
            standings.GoalsScored.Should().Be(1);
            standings.GoalsConceded.Should().Be(2);
            standings.Points.Should().Be(0);
        }

        [Fact]
        public void AddRecord_ShouldIncreaseMatchesPlayedAndGoals_WhenTeamDraws()
        {
            // Arrange
            var standings = new Standings(1);

            // Act
            standings.AddRecord(1, 1);

            // Assert
            standings.MatchesPlayed.Should().Be(1);
            standings.Draws.Should().Be(1);
            standings.GoalsScored.Should().Be(1);
            standings.GoalsConceded.Should().Be(1);
            standings.Points.Should().Be(1);
        }

        [Fact]
        public void RemoveRecord_ShouldDecreaseMatchesPlayedAndGoals_WhenTeamWins()
        {
            // Arrange
            var standings = new Standings(1);
            standings.AddRecord(2, 1);

            // Act
            standings.RemoveRecord(2, 1);

            // Assert
            standings.MatchesPlayed.Should().Be(0);
            standings.Wins.Should().Be(0);
            standings.GoalsScored.Should().Be(0);
            standings.GoalsConceded.Should().Be(0);
            standings.Points.Should().Be(0);
        }

        [Fact]
        public void RemoveRecord_ShouldDecreaseMatchesPlayedAndGoals_WhenTeamLoses()
        {
            // Arrange
            var standings = new Standings(1);
            standings.AddRecord(1, 2);

            // Act
            standings.RemoveRecord(1, 2);

            // Assert
            standings.MatchesPlayed.Should().Be(0);
            standings.Losses.Should().Be(0);
            standings.GoalsScored.Should().Be(0);
            standings.GoalsConceded.Should().Be(0);
            standings.Points.Should().Be(0);
        }

        [Fact]
        public void RemoveRecord_ShouldDecreaseMatchesPlayedAndGoals_WhenTeamDraws()
        {
            // Arrange
            var standings = new Standings(1);
            standings.AddRecord(1, 1);

            // Act
            standings.RemoveRecord(1, 1);

            // Assert
            standings.MatchesPlayed.Should().Be(0);
            standings.Draws.Should().Be(0);
            standings.GoalsScored.Should().Be(0);
            standings.GoalsConceded.Should().Be(0);
            standings.Points.Should().Be(0);
        }

        [Fact]
        public void UpdateRecord_ShouldRevertOldRecordAndAddNewRecord_WhenUpdatingFromWinToLoss()
        {
            // Arrange
            var standings = new Standings(1);
            standings.AddRecord(2, 1);

            // Act
            standings.UpdateRecord(2, 1, 1, 2);

            // Assert
            standings.MatchesPlayed.Should().Be(1);
            standings.Wins.Should().Be(0);
            standings.Losses.Should().Be(1);
            standings.GoalsScored.Should().Be(1);
            standings.GoalsConceded.Should().Be(2);
            standings.Points.Should().Be(0);
        }
    }
}
