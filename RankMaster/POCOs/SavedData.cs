using System.Text.Json;

namespace RankMaster.POCOs;

public class SavedData
{
    private static readonly string FilePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "RankMaster", "data.json");

    public static SavedData Instance { get; } = new();
    public List<string> TournamentIds { get; set; } = [];
    public static IEnumerable<Participant> Participants { get; set; } = new List<Participant>();

    public static SavedData Load()
    {
        // Load data from default app data location
        if (!File.Exists(FilePath))
        {
            // If the file doesn't exist, return a new instance
            return Instance;
        }

        // Deserialize the data from the file
        var data = JsonSerializer.Deserialize<SavedData>(File.ReadAllText(FilePath));

        // Return the deserialized data
        // If the data is null, return a new instance
        return data ?? Instance;
    }

    public static void Save(SavedData savedData)
    {
        // Serialize the data to a JSON string
        var json = JsonSerializer.Serialize(savedData);

        // Ensure the directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(FilePath) ?? string.Empty);

        // Write the JSON string to the file
        File.WriteAllText(FilePath, json);
    }
}