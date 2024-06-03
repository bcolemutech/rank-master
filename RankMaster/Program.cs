using RankMaster;
using RankMaster.POCOs;
using RankMaster.Services;
using Spectre.Console;

AnsiConsole.Write(new FigletText("Welcome to RankMaster!").LeftJustified().Color(Color.Green));

AnsiConsole.MarkupLine("Welcome to [bold green]RankMaster[/]!");

// Validate an API Key is set
var apiKey = Environment.GetEnvironmentVariable("CHALLONGE_API_KEY");
if (string.IsNullOrEmpty(apiKey))
{
    AnsiConsole.MarkupLine(
        "[bold red]Error:[/] No Challonge API Key found. Please set the CHALLONGE_API_KEY environment variable.");
    return;
}

// Create a new Challonge API client
var challonge = new ChallongeClient(apiKey);

// Main loop
while (true)
{
    // Get saved data from saved app data
    var savedData = SavedData.Load();
    // Get tournament details for each tournament in the saved data
    var tournaments = savedData.TournamentIds.Select(tournamentId => challonge.GetTournament(tournamentId)).ToList();

    // Create a Table for the tournament data
    var table = new Table();
    table.AddColumn("ID");
    table.AddColumn("Tournament");
    table.AddColumn("Type");
    table.AddColumn("State");
    table.AddColumn("Participants");

    // Add rows to the table
    foreach (var tournament in tournaments)
    {
        table.AddRow(tournament.Id.ToString(), tournament.Attributes.Name, tournament.Attributes.Type, tournament.Attributes.State,
            tournament.Relationships.Participants.Links.Meta.Count.ToString());
    }

    // Render the table
    AnsiConsole.Write(table);

    // Prompt the to edit the Tournament data, open participants screen, or exit
    var choice = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("What would you like to do?")
        .PageSize(3)
        .AddChoices(["Edit Tournament Data", "Open Participants Screen", "Exit"]));

    // Handle the user's choice
    switch (choice)
    {
        case "Edit Tournament Data":
            AnsiConsole.MarkupLine("Editing Tournament Data...");
            TournamentService.EditTournamentData(challonge, tournaments);
            continue;
        case "Open Participants Screen":
            AnsiConsole.MarkupLine("Opening Participants Screen...");
            ParticipantService.OpenParticipantsScreen(challonge, SavedData.Participants);
            break;
        case "Exit":
            AnsiConsole.MarkupLine("Exiting...");
            Environment.Exit(0);
            break;
        default:
            AnsiConsole.MarkupLine("[bold red]Error:[/] Invalid choice.");
            throw new InvalidOperationException("Invalid choice.");
    }

    break;
}