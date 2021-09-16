namespace TennisMatch.Core.Interfaces
{
    public interface ITieBreaker
    {
        bool Calculate(IPlayerSet playerSetWinner, IPlayerSet playerSetLooser);
    }

}

