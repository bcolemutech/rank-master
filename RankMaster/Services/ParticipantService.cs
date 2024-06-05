namespace RankMaster.Services;

using System.Globalization;
using POCOs;
using Spectre.Console;

public class ParticipantService
{
    public static void OpenParticipantsScreen(ChallongeClient challonge, SavedData savedData)
    {
        // Participants screen loop
        while (true)
        {
            var table = new Table();
            AnsiConsole.Status().Start("Loading participants...", ctx =>
            {
                ctx.Spinner(Spinner.Known.Dots);
                // Build table for saved participants
                table.AddColumn("ID");
                table.AddColumn("Name");
                table.AddColumn("Username");
                table.AddColumn("Wins");
                table.AddColumn("Losses");
                table.AddColumn("Win Percentage");
                table.AddColumn("Handicap");

                // Add rows to the table
                foreach (var participant in savedData.Participants)
                {
                    table.AddRow(participant.Id, participant.Attributes.Name, participant.Attributes.Username,
                        participant.Wins.ToString(), participant.Losses.ToString(),
                        participant.WinPercentage.ToString(CultureInfo.InvariantCulture),
                        participant.Handicap.ToString());
                }
            });

            AnsiConsole.MarkupLine("Participants identified:");
            AnsiConsole.Write(table);
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("What would you like to do?")
                    .PageSize(3)
                    .AddChoices(
                        [
                            "Update Participants and calculate handicaps",
                            "Exit"
                        ]
                    ));
            switch (choice)
            {
                case "Update Participants and calculate handicaps":
                    UpdateParticipants(challonge, savedData);
                    break;
                case "Exit":
                    return;
            }
        }
    }

    private static void UpdateParticipants(ChallongeClient challonge, SavedData savedData)
    {
        AnsiConsole.Status().Start("Updating participants...", ctx =>
        {
            ctx.Status("Getting participants from Challonge...");
            ctx.Spinner(Spinner.Known.Dots);

            // Get participants from Challonge
            var participants = new List<Participant>();
            foreach (var tournamentId in savedData.TournamentIds)
            {
                participants.AddRange(challonge.GetParticipants(tournamentId));
            }

            participants = participants.GroupBy(p => p.Id).Select(g => g.First()).ToList();

            ctx.Status("Calculating handicaps...");
            // Calculate handicaps
            foreach (var participant in participants)
            {
                var wins = 0;
                var losses = 0;
                foreach (var tournamentId in savedData.TournamentIds)
                {
                    var matches = challonge.GetMatches(tournamentId, participant.Id);
                    // get total wins and losses
                    foreach (var match in matches)
                    {
                        foreach (var score in match.Attributes.PointsByParticipant)
                        {
                            if (score.ParticipantId.ToString() == participant.Id)
                            {
                                wins += score.Scores.Sum();
                            }
                            else
                            {
                                losses += score.Scores.Sum();
                            }
                        }
                    }
                }
                participant.Wins = wins;
                participant.Losses = losses;
                var totalGames = wins + losses;
                participant.Handicap = RankService.CalculateRank(totalGames, wins);
            }

            savedData.Participants = participants;

            ctx.Status("Saving participants...");
            // Save participants
            SavedData.Save(savedData);
        });
    }
}