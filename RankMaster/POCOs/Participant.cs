namespace RankMaster.POCOs;

using System.Text.Json.Serialization;

[JsonSerializable(typeof(Participant))]
public class Participant
{ 
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("attributes")]
    public ParticipantAttributes Attributes { get; set; } = new();

    [JsonPropertyName("wins")]
    public int Wins { get; set; }

    [JsonPropertyName("losses")]
    public int Losses { get; set; }
    
    [JsonIgnore]
    public decimal WinPercentage => Wins + Losses == 0 ? 0 : Math.Round((decimal)Wins / (Wins + Losses) * 100, 2);

    [JsonPropertyName("handicap")]
    public decimal Handicap { get; set; }
}