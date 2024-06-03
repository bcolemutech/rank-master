﻿using System.Text.Json.Serialization;

namespace RankMaster.POCOs;

[JsonSerializable(typeof(TournamentWrapper))]
public class TournamentWrapper
{
    [JsonPropertyName("attributes")]
    public TournamentAttributes Attributes { get; set; }
    [JsonPropertyName("relationships")]
    public TournamentRelationships Relationships { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }
}