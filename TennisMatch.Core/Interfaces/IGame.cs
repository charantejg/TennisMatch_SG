namespace TennisMatch.Core.Interfaces
{
    public interface IGame
    {
        string GameScoreBoard();
        bool IsGameCompleted { get; }
        void CurrentPointWinner(IPlayer player);
        string GetPlayerGamePoints(IPlayer player);
        IPlayer Winner { get; }
    }

    
}