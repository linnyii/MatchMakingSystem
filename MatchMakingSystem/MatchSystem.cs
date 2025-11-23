using MatchMakingSystem.Models;
namespace MatchMakingSystem;

public class MatchSystem(IMatchMakingStrategy strategy, Individual self, List<Individual> individuals )
{
   private IMatchMakingStrategy Strategy { get; } = strategy;
   private Individual Self { get; } = self;
   private List<Individual> Individuals { get; } = individuals;

   public void Match()
   {
      Console.WriteLine($"===== {Strategy.GetDescription()} ====");
      var matchList = Strategy.Match(Self, Individuals);
      Strategy.DisplayResults(Self, matchList);
   }
}