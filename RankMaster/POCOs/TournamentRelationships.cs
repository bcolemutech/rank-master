using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

[JsonSerializable(typeof(TournamentRelationships))]
public class TournamentRelationships
{
    [JsonPropertyName("participants")]
    public TournamentParticipants Participants { get; set; }
}