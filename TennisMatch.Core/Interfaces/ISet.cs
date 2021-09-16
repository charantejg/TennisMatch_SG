namespace TennisMatch.Core.Interfaces
{
    public interface ISet
    {
        bool GameEnd { get; }

        string DisplayScoreBoard(IPlayer player);
        void CurrentPointWinner(IPlayer player);

        bool SetEnd { get; }
        IPlayer Winner { get;  }
        bool IsTieBreaker { get; set; }

    }
}