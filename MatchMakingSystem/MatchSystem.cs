using MatchMakingSystem.Models;
namespace MatchMakingSystem;

public class MatchSystem(IMatchMakingStrategy strategy)
{
   private IMatchMakingStrategy Strategy { get; } = strategy;
   public required Individual Self { get; init; }
   public required List<Individual> Individuals { get; init; }

   public void Match()
   {
      Console.WriteLine($"===== {Strategy.GetDescription()} ====");
      var matchList = Strategy.Match(Self, Individuals);
      Strategy.DisplayResults(Self, matchList);
   }
}