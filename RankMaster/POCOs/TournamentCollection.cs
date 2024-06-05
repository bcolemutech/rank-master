using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

public class TournamentCollection
{
    [JsonPropertyName("data")]
    public IEnumerable<Tournament> Tournaments { get; set; }
}