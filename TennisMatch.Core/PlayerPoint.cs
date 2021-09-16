using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public class PlayerPoint: IPlayerPoint
    {
        public PlayerPoint(IPlayer player)
        {
            this.Player = player;
            Point = new Point();
        }

        public IPoint Point { get; set; }
        public IPlayer Player { get; }
        public bool IsWinner => Point is PointWin;
        public bool HasScoreForty => Point is Point {PointValue: 40};
        public bool HasScoreLessThanForty => Point is Point {PointValue: <40};
        public bool IsDeuce => Point is PointDeuce;
        public bool IsAdvantage => Point is PointAdvantage;
    

        /// <summary>
        /// Increment method is to move points from 0->15->30 and update current score value
        /// </summary>
        public void Increment()
        {
            Point = NextScore(Point);
        }

       /// <summary>
       /// Predicts the next score 
       /// </summary>
       /// <param name="point"></param>
       /// <returns></returns>
        private IPoint NextScore(IPoint point)
        {
            switch (point.PointValue)
            {
                case 0:
                    return new Point(15);
                case 15:
                    return new Point(30);
              
                default:
                    return new Point(40);
            }
        }


        public void Win()
        {
            Point = new PointWin();
        }

        public void Forty()
        {
            Point = new Point(40);
        }

        public void Deuce()
        {
            Point = new PointDeuce();
        }

        public void Advantage()
        {
            Point = new PointAdvantage();
        }
    }

   
}