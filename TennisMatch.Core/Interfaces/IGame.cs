namespace TennisMatch.Core.Interfaces
{
    public interface IGame
    {
        string GameScoreBoard();
        bool IsGameCompleted { get; }
        void CurrentPointWinner(IPlayer player);
        string GetPlayerScore(IPlayer player);
    }

    
}