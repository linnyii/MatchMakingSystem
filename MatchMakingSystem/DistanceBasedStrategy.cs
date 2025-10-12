using MatchMakingSystem.Models;

namespace MatchMakingSystem;

public class DistanceBasedStrategy : IMatchMakingStrategy
{
    public List<Individual> Match(Individual self, List<Individual> individuals)
    {
        return individuals
            .OrderBy(individual => CalculateDistance(self.Coord, individual.Coord))
            .ThenBy(individual => individual.Id)
            .ToList();
    }

    private double CalculateDistance(Coord coord1, Coord coord2)
    {
        double deltaX = coord2.X - coord1.X;
        double deltaY = coord2.Y - coord1.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}