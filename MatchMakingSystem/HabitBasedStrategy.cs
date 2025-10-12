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

    private int CalculateHabitIntersection(List<string> habits1, List<string> habits2)
    {
        return habits1.Intersect(habits2).Count();
    }
}