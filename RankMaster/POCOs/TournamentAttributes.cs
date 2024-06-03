using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

[JsonSerializable(typeof(TournamentAttributes))]
public class TournamentAttributes
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("tournament_type")]
    public string Type { get; set; }
    [JsonPropertyName("state")]
    public string State { get; set; }
}