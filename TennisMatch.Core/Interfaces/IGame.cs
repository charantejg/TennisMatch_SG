namespace TennisMatch.Core.Interfaces
{
    public interface IGame
    {
        string GameScoreBoard();
        bool IsGameCompleted { get; }
        void UpdatePoints(IPlayer player);
        string GetPlayerScore(IPlayer player);
    }

    
}