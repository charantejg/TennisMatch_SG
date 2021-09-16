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
           if (IsGameCompleted)
           {
               return $"{Winner.Name} wins the game point";
           }
           return $"{_playerScoreA.Player.Name}:{_playerScoreA.Score.ToString()}," +
                  $"{_playerScoreB.Player.Name}:{_playerScoreB.Score.ToString()}";
       }

       public bool IsGameCompleted => Winner != null;

        public IPlayer Winner
        {
            get
            {
                if (_playerScoreA.IsWinner)
                    return _playerScoreA.Player;
                if (_playerScoreB.IsWinner)
                    return _playerScoreB.Player;
                return null;
            }
        }
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
           

            if (winner.HasScoreForty)
            {
                winner.Win();
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
