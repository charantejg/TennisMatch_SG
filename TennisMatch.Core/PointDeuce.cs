using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public struct PointDeuce: IPoint
    {
        //Assume the advantage score is 41, in reality there is no 41 in tennis.
        // this is just to differentiate from forty score 
        public int PointValue => 41;

       
        public override string ToString()
        {
            return "Deuce";
        }

    }
}