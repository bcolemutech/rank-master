using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

[JsonSerializable(typeof(Links))]
public class Links
{
    [JsonPropertyName("related")]
    public string Related { get; set; }
    [JsonPropertyName("meta")]
    public Meta Meta { get; set; }
}