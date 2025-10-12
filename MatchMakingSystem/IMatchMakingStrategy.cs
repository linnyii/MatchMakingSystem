using MatchMakingSystem.Models;

namespace MatchMakingSystem;

public interface IMatchMakingStrategy
{
    public List<Individual> Match(Individual self, List<Individual> individuals);
}