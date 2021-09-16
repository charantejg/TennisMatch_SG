namespace TennisMatch.Core.Interfaces
{
    public interface IPlayerPoint
    {
        IPoint Point { get; set; }
        IPlayer Player { get; }
        bool IsWinner { get; }
        bool HasScoreForty { get; }
        bool HasScoreLessThanForty { get;  }
        bool IsDeuce { get; }
        bool IsAdvantage { get; }

        void Increment();
        void Win();
        void Forty();
        void Deuce();
        void Advantage();
        

    }
}