using MatchMakingSystem.Models;

namespace MatchMakingSystem;

public static class IndividualPrinter
{
    public static void PrintIndividual(Individual individual)
    {
        Console.WriteLine($"Gender: {individual.Gender}");
        Console.WriteLine($"Age: {individual.Age}");
        Console.WriteLine($"Intro: {individual.Intro}");
        Console.WriteLine($"Habits: {string.Join(", ", individual.Habits)}");
        Console.WriteLine($"Coord: ({individual.Coord.X}, {individual.Coord.Y})");
    }

    public static void PrintMatchList(List<Individual> matchList)
    {
        foreach (var individual in matchList)
        {
            Console.WriteLine($"ID: {individual.Id}");
            PrintIndividual(individual);
            Console.WriteLine("---");
        }
    }
}

