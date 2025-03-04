using System.Text.Json.Serialization;
using System.Text.Json;

namespace SleeperDashboard.Dto.Player
{
    public class Player
    {
        public string? Hashtag { get; set; }
        public int DepthChartPosition { get; set; }
        public string? Status { get; set; }
        public string? Sport { get; set; }
        public List<string>? FantasyPositions { get; set; }

        [JsonConverter(typeof(StringOrIntConverter))]
        public int? Number { get; set; }
        public string? SearchLastName { get; set; }
        public object? InjuryStartDate { get; set; }
        public string? Weight { get; set; }
        public string? Position { get; set; }
        public object? PracticeParticipation { get; set; }
        public string? SportradarId { get; set; }
        public string? Team { get; set; }
        public string? LastName { get; set; }
        public string? College { get; set; }
        public int FantasyDataId { get; set; }
        public object? InjuryStatus { get; set; }
        public string? PlayerId { get; set; }
        public string? Height { get; set; }
        public string? SearchFullName { get; set; }

        [JsonConverter(typeof(StringOrIntConverter))]
        public int? Age { get; set; }
        public string? StatsId { get; set; }
        public string? BirthCountry { get; set; }
        public string? EspnId { get; set; }
        public int SearchRank { get; set; }
        public string? FirstName { get; set; }
        public int DepthChartOrder { get; set; }
        public int YearsExp { get; set; }
        public object? RotowireId { get; set; }
        public int RotoworldId { get; set; }
        public string? SearchFirstName { get; set; }
        public object? YahooId { get; set; }

        class StringOrIntConverter : JsonConverter<int?>
        {
            public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Number)
                {
                    return reader.GetInt32();
                }
                else if (reader.TokenType == JsonTokenType.String && int.TryParse(reader.GetString(), out int value))
                {
                    return value;
                }
                return null;  // Handle cases where age is missing or invalid
            }

            public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
            {
                if (value.HasValue)
                {
                    writer.WriteNumberValue(value.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }
            }
        }
    }
}
