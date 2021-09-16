using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public class PlayerGameScore: IPlayerGameScore
    {
        public PlayerGameScore(IPlayer player)
        {
            this.Player = player;
            Score = new Score();
        }

        public IScore Score { get; set; }
        public IPlayer Player { get; }
        public bool IsWinner { get; }
        public bool HasScoreForty { get; }
        public bool HasScoreLessThanForty { get; }
    

        /// <summary>
        /// Increment method is to move points from 0->15->30 and update current score value
        /// </summary>
        public void Increment()
        {
            Score = NextScore(Score);
        }

       
        private IScore NextScore(IScore score)
        {
            switch (score.PointValue)
            {
                case 0:
                    return new Score(15);
                case 15:
                    return new Score(30);
                 
                default:
                    return new Score(40);
            }
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