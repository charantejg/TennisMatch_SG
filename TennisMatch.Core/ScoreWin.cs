using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public class ScoreWin : IScore
    {
        public ScoreWin()
        {
            PointValue = 1;
        }

        public int PointValue { get; set; }

        public override string ToString()
        {
            return PointValue.ToString();
        }
    }
}
