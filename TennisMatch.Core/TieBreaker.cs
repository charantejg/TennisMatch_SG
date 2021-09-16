using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public class TieBreaker: ITieBreaker
    {
        public bool Calculate(IPlayerSet playerSetWinner, IPlayerSet playerSetLooser)
        {
            playerSetWinner.TieBreakerScore++;

            //	The Tie-Break ends as soon as a player gets a least 6 points and gets 2 points more than his opponent
            if (playerSetWinner.TieBreakerScore >= 6 && (playerSetWinner.TieBreakerScore - playerSetLooser.TieBreakerScore >= 2))
            {
                playerSetWinner.Score++;
                return true;
            }

            return false;
        }


       
    }
}
