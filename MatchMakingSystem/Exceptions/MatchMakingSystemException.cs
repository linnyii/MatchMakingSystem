namespace MatchMakingSystem.Exceptions;

public class MatchMakingSystemException(string message) : Exception(message)
{
    public static MatchMakingSystemException NoStrategyFound()
    {
        return new MatchMakingSystemException($"Please indicate valid Strategy name for ReverseStrategy");
    }

    public static Exception InvalidStrategy(string strategy)
    {
        return new MatchMakingSystemException($"Unsupported Strategy Name for ReverseStrategy: {strategy}");
    }
}