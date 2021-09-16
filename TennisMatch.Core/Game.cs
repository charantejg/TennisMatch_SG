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
       private readonly IPlayerPoint _playerScoreA;
       private readonly IPlayerPoint _playerScoreB;

       public Game(IPlayer playerA, IPlayer playerB)
       {
           _playerScoreA = new PlayerPoint(playerA);
           _playerScoreB = new PlayerPoint(playerB);
       }

       public string GameScoreBoard()
       {
           if (IsGameCompleted)
           {
               return $"{Winner.Name} wins the game point";
           }

           
           return $"{_playerScoreA.Player.Name}:{_playerScoreA.Point.ToString()}," +
                  $"{_playerScoreB.Player.Name}:{_playerScoreB.Point.ToString()}";


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
        /// <summary>
        /// Main logical block for incrementing the game score
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

        public string GetPlayerScore(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
