using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

[JsonSerializable(typeof(TournamentParticipants))]
public class TournamentParticipants
{
    [JsonPropertyName("links")]
    public Links Links { get; set; }
}