using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

public class TournamentSingle
{
    [JsonPropertyName("data")]
    public Tournament Tournament { get; set; }
}