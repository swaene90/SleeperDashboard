using Newtonsoft.Json;

namespace SleeperDashboard.Model.Player
{
    public class Player
    {
        public string? Id { get; set; }

        [JsonProperty("practice_participation")]
        public object? PracticeParticipation { get; set; }

        [JsonProperty("team")]
        public string? Team { get; set; }

        [JsonProperty("weight")]
        public string? Weight { get; set; }

        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        [JsonProperty("competitions")]
        public List<object>? Competitions { get; set; }

        [JsonProperty("search_full_name")]
        public string? SearchFullName { get; set; }

        [JsonProperty("high_school")]
        public string? HighSchool { get; set; }

        [JsonProperty("rotoworld_id")]
        public int? RotoworldId { get; set; }

        [JsonProperty("rotowire_id")]
        public int? RotowireId { get; set; }

        [JsonProperty("depth_chart_order")]
        public int? DepthChartOrder { get; set; }

        [JsonProperty("active")]
        public bool? Active { get; set; }

        [JsonProperty("swish_id")]
        public int? SwishId { get; set; }

        [JsonProperty("team_changed_at")]
        public object? TeamChangedAt { get; set; }

        [JsonProperty("fantasy_positions")]
        public List<string>? FantasyPositions { get; set; }

        [JsonProperty("sport")]
        public string? Sport { get; set; }

        [JsonProperty("search_rank")]
        public int? SearchRank { get; set; }

        [JsonProperty("search_last_name")]
        public string? SearchLastName { get; set; }

        [JsonProperty("yahoo_id")]
        public int? YahooId { get; set; }

        [JsonProperty("birth_country")]
        public object? BirthCountry { get; set; }

        [JsonProperty("team_abbr")]
        public object? TeamAbbr { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("oddsjam_id")]
        public string? OddsjamId { get; set; }

        [JsonProperty("espn_id")]
        public int? EspnId { get; set; }

        [JsonProperty("news_updated")]
        public long? NewsUpdated { get; set; }

        [JsonProperty("depth_chart_position")]
        public string? DepthChartPosition { get; set; }

        [JsonProperty("age")]
        public int? Age { get; set; }

        [JsonProperty("years_exp")]
        public int? YearsExp { get; set; }

        [JsonProperty("injury_notes")]
        public object? InjuryNotes { get; set; }

        [JsonProperty("birth_date")]
        public string? BirthDate { get; set; }

        [JsonProperty("injury_body_part")]
        public object? InjuryBodyPart { get; set; }

        [JsonProperty("opta_id")]
        public object? OptaId { get; set; }

        [JsonProperty("injury_start_date")]
        public object? InjuryStartDate { get; set; }

        [JsonProperty("player_id")]
        public string? PlayerId { get; set; }

        [JsonProperty("hashtag")]
        public string? Hashtag { get; set; }

        [JsonProperty("pandascore_id")]
        public object? PandascoreId { get; set; }

        [JsonProperty("injury_status")]
        public object? InjuryStatus { get; set; }

        [JsonProperty("height")]
        public string? Height { get; set; }

        [JsonProperty("full_name")]
        public string? FullName { get; set; }

        [JsonProperty("gsis_id")]
        public string? GsisId { get; set; }

        [JsonProperty("sportradar_id")]
        public string? SportradarId { get; set; }

        [JsonProperty("birth_city")]
        public object? BirthCity { get; set; }

        [JsonProperty("position")]
        public string? Position { get; set; }

        [JsonProperty("number")]
        public int? Number { get; set; }

        [JsonProperty("fantasy_data_id")]
        public int? FantasyDataId { get; set; }

        [JsonProperty("stats_id")]
        public int? StatsId { get; set; }

        [JsonProperty("college")]
        public string? College { get; set; }

        [JsonProperty("practice_description")]
        public object? PracticeDescription { get; set; }

        [JsonProperty("birth_state")]
        public object? BirthState { get; set; }

        [JsonProperty("last_name")]
        public string? LastName { get; set; }

        [JsonProperty("search_first_name")]
        public string? SearchFirstName { get; set; }

        [JsonProperty("first_name")]
        public string? FirstName { get; set; }
    }
}

