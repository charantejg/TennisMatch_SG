using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public struct ScoreDeuce: IScore
    {
        public int PointValue => 40;

       
        public override string ToString()
        {
            return "Deuce";
        }

    }
}