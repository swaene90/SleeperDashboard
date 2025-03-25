namespace SleeperDashboard.Model.Roster
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class TeamMetadata
    {
        [JsonProperty("record")]
        public string Record { get; set; }

        [JsonProperty("streak")]
        public string Streak { get; set; }
    }

    public class TeamSettings
    {
        [JsonProperty("fpts")]
        public int Fpts { get; set; }

        [JsonProperty("fpts_against")]
        public int FptsAgainst { get; set; }

        [JsonProperty("fpts_against_decimal")]
        public int FptsAgainstDecimal { get; set; }

        [JsonProperty("fpts_decimal")]
        public int FptsDecimal { get; set; }

        [JsonProperty("losses")]
        public int Losses { get; set; }

        [JsonProperty("ppts")]
        public int Ppts { get; set; }

        [JsonProperty("ppts_decimal")]
        public int PptsDecimal { get; set; }

        [JsonProperty("ties")]
        public int Ties { get; set; }

        [JsonProperty("total_moves")]
        public int TotalMoves { get; set; }

        [JsonProperty("waiver_budget_used")]
        public int WaiverBudgetUsed { get; set; }

        [JsonProperty("waiver_position")]
        public int WaiverPosition { get; set; }

        [JsonProperty("wins")]
        public int Wins { get; set; }
    }

    public class Roster
    {
        [JsonProperty("co_owners")]
        public object CoOwners { get; set; }  // Nullable field

        [JsonProperty("keepers")]
        public object Keepers { get; set; }   // Nullable field

        [JsonProperty("league_id")]
        public string LeagueId { get; set; }

        [JsonProperty("metadata")]
        public TeamMetadata Metadata { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }

        [JsonProperty("player_map")]
        public object PlayerMap { get; set; } // Nullable field

        [JsonProperty("players")]
        public List<string> Players
        {
            get; set;
        }

        [JsonProperty("reserve")]
        public List<string> Reserve { get; set; }

        [JsonProperty("roster_id")]
        public int RosterId { get; set; }

        [JsonProperty("settings")]
        public TeamSettings Settings { get; set; }

        [JsonProperty("starters")]
        public List<string> Starters { get; set; }

        [JsonProperty("taxi")]
        public object Taxi { get; set; }
    }
}
