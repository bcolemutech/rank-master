using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

public class TournamentSingle
{
    [JsonPropertyName("data")]
    public TournamentWrapper Data { get; set; }
}