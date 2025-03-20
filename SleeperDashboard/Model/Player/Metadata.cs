using Newtonsoft.Json;

namespace SleeperDashboard.Model.Player
{
    public class Metadata
    {
        [JsonProperty("channel_id")]
        public string? ChannelId { get; set; }

        [JsonProperty("rookie_year")]
        public string? RookieYear { get; set; }
    }
}
