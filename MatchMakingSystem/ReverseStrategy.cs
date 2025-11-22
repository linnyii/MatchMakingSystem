using MatchMakingSystem.Exceptions;
using MatchMakingSystem.Models;

namespace MatchMakingSystem;

public class ReverseStrategy(IMatchMakingStrategy strategy) : IMatchMakingStrategy
{
    private IMatchMakingStrategy InnerStrategy { get; } = strategy;

    public List<Individual> Match(Individual self, List<Individual> individuals)
    {
        var result = InnerStrategy.Match(self, individuals);
        result.Reverse();
        return result;
    }

    public void DisplayResults(Individual self, List<Individual> matchList)
    {
        switch (InnerStrategy)
        {
            case DistanceBasedStrategy:
                Console.WriteLine("People who are from the farest to the nearest ");
                IndividualPrinter.PrintMatchList(matchList);
                Console.WriteLine($"People who is away from the farest is {matchList[0].Id}");
                IndividualPrinter.PrintIndividual(matchList[0]);
                Console.WriteLine("Your personal Data");
                IndividualPrinter.PrintIndividual(self);
                break;
            case HabitBasedStrategy:
                Console.WriteLine("People who are with common habits with u. From the least to the most common");
                IndividualPrinter.PrintMatchList(matchList);
                Console.WriteLine($"People who is with the least common habits with u is {matchList[0].Id}");
                IndividualPrinter.PrintIndividual(matchList[0]);
                Console.WriteLine("Your personal Data");
                IndividualPrinter.PrintIndividual(self);
                break;
            default:
                throw MatchMakingSystemException.InvalidStrategy(InnerStrategy.GetType().ToString());
        }
    }

    public string GetDescription()
    {
        return $"Reverse {InnerStrategy.GetDescription()}";
    }
}