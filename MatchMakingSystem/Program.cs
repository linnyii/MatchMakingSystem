using MatchMakingSystem;
using MatchMakingSystem.Enum;
using MatchMakingSystem.Models;

var (self, individuals) = CreateTestData();

RunMatchMaking(new DistanceBasedStrategy(), self, individuals);
return;

// RunMatchMaking(new HabitBasedStrategy(), self, individuals);
// RunMatchMaking(new ReverseStrategy(new DistanceBasedStrategy()), self, individuals);
// RunMatchMaking(new ReverseStrategy(new HabitBasedStrategy()), self, individuals);
static void RunMatchMaking(IMatchMakingStrategy strategy, Individual self, List<Individual> individuals)
{
    var matchMakingSystem = new MatchSystem(strategy, self, individuals);
    matchMakingSystem.Match();
}

static (Individual self, List<Individual> individuals) CreateTestData()
{
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

    return (self, individuals);
}