using MatchMakingSystem.Enum;

namespace MatchMakingSystem.Models;

public class Individual
{
    public int Id { get; init; }
    public Gender Gender { get; init; }
    public int Age { get; init; }
    public string Intro { get; init; } = null!;
    public List<string> Habits { get; init; } = null!;
    public required Coord Coord { get; init; }
}