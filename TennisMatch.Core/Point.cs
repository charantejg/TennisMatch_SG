using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public struct Point: IPoint
    {
        public Point(int newPoint = 0)
        {
            PointValue = newPoint;
        }

        public int PointValue { get; }

        public override string ToString()
        {
            return PointValue.ToString();
        }
    }
}
