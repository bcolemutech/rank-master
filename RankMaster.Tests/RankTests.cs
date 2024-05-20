using FluentAssertions;
using RankMaster.Services;

namespace RankMaster.Tests;

public class RankTests
{
    [Theory]
    [InlineData(0, 0, 3)]
    [InlineData(1, 0, 3)]
    [InlineData(1, 1, 3)]
    [InlineData(2, 1, 3)]
    [InlineData(2, 2, 4)]
    [InlineData(3, 2, 4)]
    [InlineData(3, 3, 4)]
    [InlineData(4, 0, 3)]
    [InlineData(4, 1, 3)]
    [InlineData(4, 2, 4)]
    [InlineData(4, 3, 4)]
    [InlineData(4, 4, 4)]
    [InlineData(5, 0, 3)]
    [InlineData(5, 1, 3)]
    [InlineData(5, 2, 3)]
    [InlineData(5, 3, 4)]
    [InlineData(5, 4, 4)]
    [InlineData(5, 5, 4)]
    [InlineData(6, 0, 3)]
    [InlineData(6, 1, 3)]
    [InlineData(6, 2, 3)]
    [InlineData(6, 3, 4)]
    [InlineData(6, 4, 4)]
    [InlineData(6, 5, 4)]
    [InlineData(6, 6, 4)]
    [InlineData(7, 0, 3)]
    [InlineData(7, 1, 3)]
    [InlineData(7, 2, 3)]
    [InlineData(7, 3, 4)]
    [InlineData(7, 4, 4)]
    [InlineData(7, 5, 4)]
    [InlineData(7, 6, 4)]
    [InlineData(7, 7, 5)]
    [InlineData(10, 0, 3)]
    [InlineData(10, 5, 4)]
    [InlineData(10, 10, 5)]
    [InlineData(15, 0, 2)]
    [InlineData(15, 5, 4)]
    [InlineData(15, 10, 5)]
    [InlineData(15, 15, 6)]
    [InlineData(20, 0, 2)]
    [InlineData(20, 3, 3)]
    [InlineData(20, 5, 3)]
    [InlineData(20, 7, 4)]
    [InlineData(20, 10, 4)]
    [InlineData(20, 12, 5)]
    [InlineData(20, 15, 6)]
    [InlineData(20, 17, 6)]
    [InlineData(20, 19, 7)]
    [InlineData(20, 20, 7)]
    public void GivenPlaysAndWinsWhenCalculateRankThenReturnExpectedRank(int plays, int wins, int expectedRank)
    {
        var rank = RankService.CalculateRank(plays, wins);
        rank.Should().Be(expectedRank);
    }
    
    [Fact]
    public void GivenMoreThan20PlaysWhenCalculateRankThenThrowException()
    {
        Action act = () => RankService.CalculateRank(21, 0);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }
}