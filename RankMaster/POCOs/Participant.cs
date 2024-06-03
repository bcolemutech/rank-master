namespace RankMaster.POCOs;

public class Participant
{
    public State States { get; set; }
}

public struct State
{
    public bool Active { get; set; }
}