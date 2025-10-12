using MatchMakingSystem.Exceptions;
using MatchMakingSystem.Models;
namespace MatchMakingSystem;

public class MatchMakingSystem(IMatchMakingStrategy strategy)
{
   private IMatchMakingStrategy Strategy { get; } = strategy;
   public required Individual Self { get; init; }
   public required List<Individual> Individuals { get; init; }

   public void Match()
   {
      switch (Strategy)
      {
         case DistanceBasedStrategy: HandleDistanceBasedStrategy();
            break;
         case HabitBasedStrategy: HandleHabitBasedStrategy();
            break;
         case ReverseStrategy: HandleReverseStrategy();
            break;
         default:
            throw MatchMakingSystemException.InvalidStrategy(Strategy.GetType().ToString());
      }
   }

   private void HandleReverseStrategy()
   {
      var matchList = Strategy.Match(Self, Individuals);
      switch (((ReverseStrategy)Strategy).InnerStrategy)
      {
        case DistanceBasedStrategy: HandleReverseDistanceBasedStrategy(matchList);
           break;
        case HabitBasedStrategy: HandleReverseHabitBasedStrategy(matchList);
           break;
        default:
           throw MatchMakingSystemException.InvalidStrategy(Strategy.GetType().ToString());
      }
   }

   private void HandleReverseHabitBasedStrategy(List<Individual> matchList)
   {
      Console.WriteLine("People who are with common habits with u. From the least to the most common");
      PrintOutMatchList(matchList);
      Console.WriteLine($"People who is with the least common habits with u is {matchList[0].Id}");
      PrintTheIndividualData(matchList[0]);
      Console.WriteLine("Your personal Data");
      PrintTheIndividualData(Self);
   }

   private void HandleReverseDistanceBasedStrategy(List<Individual> matchList)
   {
      Console.WriteLine("People who are from the farest to the nearest ");
      PrintOutMatchList(matchList);
      Console.WriteLine($"People who is away from the farest is {matchList[0].Id}");
      PrintTheIndividualData(matchList[0]);
      Console.WriteLine("Your personal Data");
      PrintTheIndividualData(Self);
   }

   private void HandleHabitBasedStrategy()
   {
      var matchList = Strategy.Match(Self, Individuals);
      Console.WriteLine("People who are with the most common habits with you. From the most to the least ");
      PrintOutMatchList(matchList);
      Console.WriteLine($"The Peron who has the most common habits with you is {matchList[0].Id}.");
      PrintTheIndividualData(matchList[0]);
      Console.WriteLine("Your personal Data");
      PrintTheIndividualData(Self);
   }

   private void HandleDistanceBasedStrategy()
   {
      var matchList = Strategy.Match(Self, Individuals);
      Console.WriteLine("People around you from nearest to farest");
      PrintOutMatchList(matchList);
      Console.WriteLine($"People who is around from nearest is {matchList[0].Id}");
      PrintTheIndividualData(matchList[0]);
      Console.WriteLine("Your personal Data");
      PrintTheIndividualData(Self);
   }

   private static void PrintTheIndividualData(Individual matchList)
   {
      Console.WriteLine($"Gender: {matchList.Gender}");
      Console.WriteLine($"Age: {matchList.Age}");
      Console.WriteLine($"Intro: {matchList.Intro}");
      Console.WriteLine($"Habits: {string.Join(", ", matchList.Habits)}");
      Console.WriteLine($"Coord: ({matchList.Coord.X}, {matchList.Coord.Y})");
   }

   private void PrintOutMatchList(List<Individual> matchList)
   {
      foreach (var individual in matchList)
      {
         Console.WriteLine($"ID: {individual.Id}");
         Console.WriteLine($"Gender: {individual.Gender}");
         Console.WriteLine($"Age: {individual.Age}");
         Console.WriteLine($"Intro: {individual.Intro}");
         Console.WriteLine($"Habits: {string.Join(", ", individual.Habits)}");
         Console.WriteLine($"Coord: ({individual.Coord.X}, {individual.Coord.Y})");
         Console.WriteLine("---");
      }
   }
}