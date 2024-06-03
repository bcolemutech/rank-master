using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

public class TournamentCollection
{
    [JsonPropertyName("data")]
    public IEnumerable<TournamentWrapper> Data { get; set; }
}