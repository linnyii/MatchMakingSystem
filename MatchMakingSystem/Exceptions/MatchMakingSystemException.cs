namespace MatchMakingSystem.Exceptions;

public class MatchMakingSystemException(string message) : Exception(message)
{
    public static Exception InvalidStrategy(string strategy)
    {
        return new MatchMakingSystemException($"Unsupported Strategy Name for ReverseStrategy: {strategy}");
    }
}