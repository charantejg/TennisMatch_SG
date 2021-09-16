using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public class PlayerGameScore: IPlayerGameScore
    {
        public PlayerGameScore(IPlayer player)
        {
            this.Player = player;
        }

        public IScore Score { get; set; }
        public IPlayer Player { get; }
        public bool IsWinner { get; }
        public bool HasScoreForty { get; }
        public bool HasScoreLessThanForty { get; }
        public void Increment()
        {
            throw new System.NotImplementedException();
        }

        public void Win()
        {
            throw new System.NotImplementedException();
        }

        public void Forty()
        {
            throw new System.NotImplementedException();
        }
    }
}