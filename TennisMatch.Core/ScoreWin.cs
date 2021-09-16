using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public struct ScoreWin : IScore
    {
        
        public int PointValue => 1;

        public override string ToString()
        {
            return PointValue.ToString();
        }
    }
}
