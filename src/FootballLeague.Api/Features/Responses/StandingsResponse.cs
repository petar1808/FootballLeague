﻿using FootballLeague.Api.Entities;

namespace FootballLeague.Api.Features.Responses
{
    public class StandingsResponse
    {
        public int RankingId { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }

        public int GoalDifference => GoalsScored - GoalsConceded;

        public int Points { get; set; }
    }
}
