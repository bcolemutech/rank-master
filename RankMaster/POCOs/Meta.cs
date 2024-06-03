using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

[JsonSerializable(typeof(Meta))]
public class Meta
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
}