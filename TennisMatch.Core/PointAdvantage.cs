using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public struct PointAdvantage: IPoint
    {
        //Assume the advantage score is 42, in reality there is no 42 in tennis.
        public int PointValue => 42;

        public override string ToString()
        {
            return "Advantage";
        }

    }
}