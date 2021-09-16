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
       private readonly IPlayerPoint _playerPointsA;
       private readonly IPlayerPoint _playerPointsB;

       public Game(IPlayer playerA, IPlayer playerB)
       {
           _playerPointsA = new PlayerPoint(playerA);
           _playerPointsB = new PlayerPoint(playerB);
       }

       public string GameScoreBoard()
       {
           if (IsGameCompleted)
           {
               return $"{Winner.Name} wins the game point";
           }

           
           return $"{_playerPointsA.Player.Name}:{_playerPointsA.Point.ToString()}," +
                  $"{_playerPointsB.Player.Name}:{_playerPointsB.Point.ToString()}";

       }

       public bool IsGameCompleted => Winner != null;

        public IPlayer Winner
        {
            get
            {
                if (_playerPointsA.IsWinner)
                    return _playerPointsA.Player;
                if (_playerPointsB.IsWinner)
                    return _playerPointsB.Player;
                return null;
            }
        }
        public void CurrentPointWinner(IPlayer player)
        {
            if (_playerPointsA.Player == player)
            {
                CalculateNewPoints(_playerPointsA, _playerPointsB);
            }
            else if(_playerPointsB.Player == player)
            {
                CalculateNewPoints(_playerPointsB, _playerPointsA);
            }

        }
        /// <summary>
        /// Main logical block for incrementing the game points
        /// </summary>
        /// <param name="playerWin">The point scored player</param>
        /// <param name="playerLoss">The player who did not score any point</param>
        private void CalculateNewPoints(IPlayerPoint playerWin, IPlayerPoint playerLoss)
        {
            //If the player who has the ADVANTAGE win the  point, he win the game
            if (playerWin.IsAdvantage)
            {
                playerWin.Win();
                return;
            }

            //If the player who has the ADVANTAGE loose the point, the score is DEUCE
            if (playerLoss.IsAdvantage)
            {
                playerLoss.Deuce();
                playerWin.Deuce();
                return;
            }

            //If the score is DEUCE , the player who  win the point take the ADVANTAGE
            if (playerWin.IsDeuce)
            {

                playerWin.Advantage();
                playerLoss.Forty();
                return;
            }

            if (playerWin.HasScoreLessThanForty && playerLoss.HasScoreLessThanForty)
            {
                playerWin.Increment();
               return;
            }

            
            if (playerWin.HasScoreForty)
            {
                playerWin.Win();
                return;
            }
            
            // used to increment the playerB
            playerWin.Increment();

            //If the 2 players reach the score 40, the DEUCE rule is activated
            if (playerWin.HasScoreForty && playerLoss.HasScoreForty)
            {
                playerWin.Deuce();
                playerLoss.Deuce();
                return;
            }

        }

        public string GetPlayerGamePoints(IPlayer player)
        {
            if (_playerPointsA.Player == player)
                return _playerPointsA.Point.ToString();
            if(_playerPointsB.Player == player)
                return _playerPointsB.Point.ToString();

            return null;
            
        }
    }
}
