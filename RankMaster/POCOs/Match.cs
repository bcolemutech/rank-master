using System.Collections;
using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

[JsonSerializable(typeof(Match))]
public class Match
{
    [JsonPropertyName("attributes")]
    public MatchAttributes Attributes { get; set; }
}

[JsonSerializable(typeof(MatchAttributes))]
public class MatchAttributes
{
    [JsonPropertyName("points_by_participant")]
    public IEnumerable<Score> PointsByParticipant { get; set; }
}

[JsonSerializable(typeof(Score))]
public class Score
{
    [JsonPropertyName("participant_id")]
    public long ParticipantId { get; set; }

    [JsonPropertyName("scores")]
    public IEnumerable<int> Scores { get; set; }
}