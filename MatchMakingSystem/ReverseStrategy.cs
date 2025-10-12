using MatchMakingSystem.Exceptions;
using MatchMakingSystem.Models;

namespace MatchMakingSystem;

public class ReverseStrategy(IMatchMakingStrategy strategy) : IMatchMakingStrategy
{
    public IMatchMakingStrategy InnerStrategy { get; } = strategy ?? throw MatchMakingSystemException.NoStrategyFound();

    public List<Individual> Match(Individual self, List<Individual> individuals)
    {
        return InnerStrategy switch
        {
            DistanceBasedStrategy => ReverseDistanceStrategy(self, individuals),
            HabitBasedStrategy => ReverseHabitStrategy(self, individuals),
            _ => throw MatchMakingSystemException.InvalidStrategy(InnerStrategy.GetType().ToString())
        };
    }

    private List<Individual> ReverseHabitStrategy(Individual self, List<Individual> individuals)
    {
        var result = InnerStrategy.Match(self, individuals);
        result.Reverse();
        return result;
    }

    private List<Individual> ReverseDistanceStrategy(Individual self, List<Individual> individuals)
    {
        var result = InnerStrategy.Match(self, individuals);
        result.Reverse();
        return result;
    }
}