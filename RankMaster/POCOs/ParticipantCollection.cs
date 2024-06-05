using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

[JsonSerializable(typeof(ParticipantCollection))]
public class ParticipantCollection
{
    [JsonPropertyName("data")]
    public IEnumerable<Participant> Participants { get; set; }
}