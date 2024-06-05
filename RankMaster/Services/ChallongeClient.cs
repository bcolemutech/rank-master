using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;
using RankMaster.POCOs;
using Match = RankMaster.POCOs.Match;

namespace RankMaster.Services
{
    public class ChallongeClient
    {
        private readonly HttpClient _client;
    
        public ChallongeClient(string apiKey)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Authorization-Type", "v1");
            _client.DefaultRequestHeaders.Add("Authorization", apiKey);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("Host", "api.challonge.com");
        
        }

        public Tournament GetTournament(string tournamentId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.challonge.com/v2.1/tournaments/{tournamentId}.json");
            request.Content = new StringContent(string.Empty, new MediaTypeHeaderValue("application/vnd.api+json"));
            var response = _client.SendAsync(request).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var data = JsonSerializer.Deserialize<TournamentSingle>(json) ?? throw new Exception("Failed to deserialize data");
            return data.Tournament;
        }

        public IEnumerable<Participant> GetParticipants(string tournamentId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.challonge.com/v2.1/tournaments/{tournamentId}/participants.json");
            request.Content = new StringContent(string.Empty, new MediaTypeHeaderValue("application/vnd.api+json"));
            var response = _client.SendAsync(request).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var data = JsonSerializer.Deserialize<ParticipantCollection>(json) ?? throw new Exception("Failed to deserialize data");
            return data.Participants;
        }

        public IEnumerable<Tournament> GetAllTournaments()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.challonge.com/v2.1/tournaments.json");
            request.Content = new StringContent(string.Empty, new MediaTypeHeaderValue("application/vnd.api+json"));
            var response = _client.SendAsync(request).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var data = JsonSerializer.Deserialize<TournamentCollection>(json) ?? throw new Exception("Failed to deserialize data");
            return data.Tournaments;
        }

        public IEnumerable<Match> GetMatches(string tournamentId, string participantId)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.challonge.com/v2.1/tournaments/{tournamentId}/matches.json?participant_id={participantId}");
            request.Content = new StringContent(string.Empty, new MediaTypeHeaderValue("application/vnd.api+json"));
            var response = _client.SendAsync(request).Result;
            var json = response.Content.ReadAsStringAsync().Result;
            var data = JsonSerializer.Deserialize<POCOs.MatchCollection>(json) ?? throw new Exception("Failed to deserialize data");
            return data.Matches;
        }
    }
}
