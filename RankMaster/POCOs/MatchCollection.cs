using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

[JsonSerializable(typeof(MatchCollection))]
public class MatchCollection
{
    [JsonPropertyName("data")]
    public IEnumerable<Match> Matches { get; set; }
}