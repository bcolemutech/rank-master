using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

[JsonSerializable(typeof(ParticipantAttributes))]
public class ParticipantAttributes
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("username")]
    public string Username { get; set; }
}