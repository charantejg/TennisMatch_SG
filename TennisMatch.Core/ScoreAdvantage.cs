using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public struct ScoreAdvantage: IScore
    {
        //Assume the advantage score is 41, in reality there is no 41 in tennis.
        public int PointValue => 41;

        public override string ToString()
        {
            return "Advantage";
        }

    }
}