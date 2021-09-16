using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public class PlayerGameScore: IPlayerGameScore
    {
        public PlayerGameScore(IPlayer player)
        {
            this.Player = player;
            Score = new ScorePoint();
        }

        public IScore Score { get; set; }
        public IPlayer Player { get; }
        public bool IsWinner => Score is ScoreWin;
        public bool HasScoreForty => Score is ScorePoint {PointValue: 40};
        public bool HasScoreLessThanForty => Score is ScorePoint {PointValue: <40};
    

        /// <summary>
        /// Increment method is to move points from 0->15->30 and update current score value
        /// </summary>
        public void Increment()
        {
            Score = NextScore(Score);
        }

       /// <summary>
       /// Predicts the next score 
       /// </summary>
       /// <param name="score"></param>
       /// <returns></returns>
        private IScore NextScore(IScore score)
        {
            switch (score.PointValue)
            {
                case 0:
                    return new ScorePoint(15);
                case 15:
                    return new ScorePoint(30);
                case 30:
                    return new ScorePoint(40);
                default:
                    return new ScorePoint(0);
            }
        }


        public void Win()
        {
            Score = new ScoreWin();
        }

        public void Forty()
        {
            Score = new ScorePoint(40);
        }
    }

   
}