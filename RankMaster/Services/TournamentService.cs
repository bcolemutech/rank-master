using RankMaster.POCOs;
using Spectre.Console;

namespace RankMaster.Services;

public class TournamentService
{
    public static void EditTournamentData(ChallongeClient challonge, IEnumerable<Tournament> tournaments)
    {
        // Get all tournaments from Challonge
        var allTournaments = challonge.GetAllTournaments();
        
        // Render MultipleChoicePrompt with all tournaments, having saved tournament checked by default
        var prompt = new MultiSelectionPrompt<Tournament>()
            .Title("Select a tournaments to include")
            .NotRequired()
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more tournaments)[/]")
            .InstructionsText("[grey](Press [green]<space>[/] to select, [green]<enter>[/] to submit)[/]")
            .UseConverter(t => t.Attributes.Name);
        
        foreach (var tournament in allTournaments)
        {
            var item = prompt.AddChoice(tournament);
            if (tournaments.Any(t => t.Id == tournament.Id))
            {
                item.Select();
            }
        }
        
        var selectedTournaments = AnsiConsole.Prompt(prompt);
        
        // Save selected tournaments to saved data
        var savedData = SavedData.Load();
        savedData.TournamentIds = selectedTournaments.Select(t => t.Id).ToList();
        SavedData.Save(savedData);
    }
}