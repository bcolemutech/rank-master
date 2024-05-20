namespace RankMaster.Services;

public class RankService
{
    public static decimal CalculateRank(int plays, int wins)
    {
        if (plays > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(plays), "Plays must be less than 20");
        }
            
        var toPlay = 20 - plays;
        var adjustedWins = wins + toPlay * 0.25m;
        var winPercentage = adjustedWins / 20 * 100;
        var rank = (winPercentage + 40) / 20;
        return Math.Round(rank, 0);
    }
}