namespace SleeperDashboard.Model.Roster
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class TeamMetadata
    {
        [JsonPropertyName("record")]
        public string Record { get; set; }

        [JsonPropertyName("streak")]
        public string Streak { get; set; }
    }

    public class TeamSettings
    {
        [JsonPropertyName("fpts")]
        public int Fpts { get; set; }

        [JsonPropertyName("fpts_against")]
        public int FptsAgainst { get; set; }

        [JsonPropertyName("fpts_against_decimal")]
        public int FptsAgainstDecimal { get; set; }

        [JsonPropertyName("fpts_decimal")]
        public int FptsDecimal { get; set; }

        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        [JsonPropertyName("ppts")]
        public int Ppts { get; set; }

        [JsonPropertyName("ppts_decimal")]
        public int PptsDecimal { get; set; }

        [JsonPropertyName("ties")]
        public int Ties { get; set; }

        [JsonPropertyName("total_moves")]
        public int TotalMoves { get; set; }

        [JsonPropertyName("waiver_budget_used")]
        public int WaiverBudgetUsed { get; set; }

        [JsonPropertyName("waiver_position")]
        public int WaiverPosition { get; set; }

        [JsonPropertyName("wins")]
        public int Wins { get; set; }
    }

    public class Roster
    {
        [JsonPropertyName("co_owners")]
        public object CoOwners { get; set; }  // Nullable field

        [JsonPropertyName("keepers")]
        public object Keepers { get; set; }   // Nullable field

        [JsonPropertyName("league_id")]
        public string LeagueId { get; set; }

        [JsonPropertyName("metadata")]
        public TeamMetadata Metadata { get; set; }

        [JsonPropertyName("owner_id")]
        public string OwnerId { get; set; }

        [JsonPropertyName("player_map")]
        public object PlayerMap { get; set; } // Nullable field

        [JsonPropertyName("players")]
        public List<string> Players
        {
            get; set;
        }

        [JsonPropertyName("reserve")]
        public List<string> Reserve { get; set; }

        [JsonPropertyName("roster_id")]
        public int RosterId { get; set; }

        [JsonPropertyName("settings")]
        public TeamSettings Settings { get; set; }

        [JsonPropertyName("starters")]
        public List<string> Starters { get; set; }

        [JsonPropertyName("taxi")]
        public object Taxi { get; set; }
    }
}
