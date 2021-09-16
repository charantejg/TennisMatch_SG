using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
   public class PlayerSet: IPlayerSet
    {
        public IPlayer Player { get; set; }
        public byte Score { get; set; }

        public PlayerSet(IPlayer player)
        {
            Player = player;
            Score = 0;  // start with Zero
            
        }

    }
}
