using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
   public class Game: IGame
   {
       private readonly IPlayerGameScore _playerScoreA;
       private readonly IPlayerGameScore _playerScoreB;

       public Game(IPlayer playerA, IPlayer playerB)
       {
           _playerScoreA = new PlayerGameScore(playerA);
           _playerScoreB = new PlayerGameScore(playerB);
       }

       public string GameScoreBoard()
        {
            throw new NotImplementedException();
        }

        public bool IsGameCompleted { get; }
        public void UpdatePoints(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public string GetPlayerScore(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
