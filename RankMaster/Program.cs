using Spectre.Console;

AnsiConsole.Write(new FigletText("Welcome to RankMaster!").LeftJustified().Color(Color.Green));

AnsiConsole.MarkupLine("Welcome to [bold green]RankMaster[/]!");
AnsiConsole.MarkupLine("Type any key to continue...");
Console.ReadKey();