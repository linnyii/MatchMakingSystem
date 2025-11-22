using MatchMakingSystem.Models;

namespace MatchMakingSystem;

public class HabitBasedStrategy : IMatchMakingStrategy
{
    public List<Individual> Match(Individual self, List<Individual> individuals)
    {
        return individuals
            .OrderByDescending(individual => CalculateHabitIntersection(self.Habits, individual.Habits))
            .ThenBy(individual => individual.Id)
            .ToList();
    }

    public void DisplayResults(Individual self, List<Individual> matchList)
    {
        Console.WriteLine("People who are with the most common habits with you. From the most to the least ");
        IndividualPrinter.PrintMatchList(matchList);
        Console.WriteLine($"The Peron who has the most common habits with you is {matchList[0].Id}.");
        IndividualPrinter.PrintIndividual(matchList[0]);
        Console.WriteLine("Your personal Data");
        IndividualPrinter.PrintIndividual(self);
    }

    public string GetDescription()
    {
        return "Habit Based Strategy";
    }

    private int CalculateHabitIntersection(List<string> habits1, List<string> habits2)
    {
        return habits1.Intersect(habits2).Count();
    }
}