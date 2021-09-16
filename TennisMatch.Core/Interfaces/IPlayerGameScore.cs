namespace TennisMatch.Core.Interfaces
{
    public interface IPlayerGameScore
    {
        IScore Score { get; set; }
        IPlayer Player { get; }
        bool IsWinner { get; }
        bool HasScoreForty { get; }
        bool HasScoreLessThanForty { get;  }

        void Increment();
        void Win();
        void Forty();
        void Deuce();
        void Advantage();

    }
}