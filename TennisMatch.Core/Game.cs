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
           return $"{_playerScoreA.Player.Name}:{_playerScoreA.Score.ToString()}," +
                  $"{_playerScoreB.Player.Name}:{_playerScoreB.Score.ToString()}";
       }

        public bool IsGameCompleted { get; }
        public void CurrentPointWinner(IPlayer player)
        {
            if (_playerScoreA.Player == player)
            {
                CalculateNewPoints(_playerScoreA, _playerScoreB);
            }
            else if(_playerScoreB.Player == player)
            {
                CalculateNewPoints(_playerScoreB, _playerScoreA);
            }

        }

        private void CalculateNewPoints(IPlayerGameScore winner, IPlayerGameScore looser)
        {
            if (winner.HasScoreLessThanForty && winner.HasScoreLessThanForty)
            {
                winner.Increment();
                return;
            }
            winner.Increment();
        }

        public string GetPlayerScore(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
