using MatchMakingSystem;
using MatchMakingSystem.Enum;
using MatchMakingSystem.Models;

var self = new Individual
{
    Id = 0,
    Gender = Gender.Male,
    Age = 25,
    Intro = "I am a software engineer who loves coding",
    Habits = ["Coding", "Reading", "Gaming", "Hiking"],
    Coord = new Coord(0, 0)
};

var individuals = new List<Individual>
{
    new()
    {
        Id = 1,
        Gender = Gender.Female,
        Age = 23,
        Intro = "Love outdoor activities",
        Habits = ["Hiking", "Reading", "Photography"],
        Coord = new Coord(3, 4)
    },
    new()
    {
        Id = 2,
        Gender = Gender.Male,
        Age = 28,
        Intro = "Tech enthusiast and gamer",
        Habits = new List<string> { "Gaming", "Coding", "Music" },
        Coord = new Coord(1, 1)
    },
    new()
    {
        Id = 3,
        Gender = Gender.Female,
        Age = 26,
        Intro = "Book lover and artist",
        Habits = ["Reading", "Painting", "Cooking"],
        Coord = new Coord(10, 10)
    },
    new()
    {
        Id = 4,
        Gender = Gender.Male,
        Age = 30,
        Intro = "Sports fan",
        Habits = ["Basketball", "Swimming"],
        Coord = new Coord(2, 3)
    }
};

Console.WriteLine("==================== Distance Based Strategy ====================");
var distanceStrategy = new DistanceBasedStrategy();
var matchMakingSystem1 = new MatchMakingSystem.MatchMakingSystem(distanceStrategy)
{
    Self = self,
    Individuals = individuals
};
matchMakingSystem1.Match();

Console.WriteLine("\n\n");

Console.WriteLine("==================== Habit Based Strategy ====================");
var habitStrategy = new HabitBasedStrategy();
var matchMakingSystem2 = new MatchMakingSystem.MatchMakingSystem(habitStrategy)
{
    Self = self,
    Individuals = individuals
};
matchMakingSystem2.Match();

Console.WriteLine("\n\n");

Console.WriteLine("==================== Reverse Distance Based Strategy ====================");
var reverseDistanceStrategy = new ReverseStrategy(new DistanceBasedStrategy());
var matchMakingSystem3 = new MatchMakingSystem.MatchMakingSystem(reverseDistanceStrategy)
{
    Self = self,
    Individuals = individuals
};
matchMakingSystem3.Match();

Console.WriteLine("\n\n");

Console.WriteLine("==================== Reverse Habit Based Strategy ====================");
var reverseHabitStrategy = new ReverseStrategy(new HabitBasedStrategy());
var matchMakingSystem4 = new MatchMakingSystem.MatchMakingSystem(reverseHabitStrategy)
{
    Self = self,
    Individuals = individuals
};
matchMakingSystem4.Match();