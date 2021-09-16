using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public class Set : ISet
    {
        public bool GameEnd { get; }
        public bool SetEnd => Winner != null;
        public IPlayer Winner { get; set; }

        private IGame _game;
        private readonly IPlayerSet _playerSetA;
        private readonly IPlayerSet _playerSetB;

        public Set(IPlayer playerA, IPlayer playerB)
        {
            _playerSetA = new PlayerSet(playerA);
            _playerSetB = new PlayerSet(playerB);
            CreateGame();

        }

        private void CreateGame()
        {
            _game = new Game(_playerSetA.Player, _playerSetB.Player);
        }


        public string DisplayScoreBoard(IPlayer player)
        {
           
          var playerSet =  GetPlayerSet(player);

          return $"{_game.GetPlayerGamePoints(player)},{playerSet.Score}";

        }

        private IPlayerSet GetPlayerSet(IPlayer player)
        {
            if (_playerSetA.Player == player)
               return _playerSetA;
            return _playerSetB.Player == player
                ? _playerSetB 
                : null;
        }

        /// <summary>
        /// Public method which is invoked by client to start a game in a set
        /// </summary>
        /// <param name="player"></param>
        public void CurrentPointWinner(IPlayer player)
        {
            if(SetEnd)
                return;
            
            if (_playerSetA.Player == player)
            {
                CalculateNewPoints(_playerSetA, _playerSetB);
            }

            if (_playerSetB.Player == player)
            {
                CalculateNewPoints(_playerSetB, _playerSetA);
            }
        }


        /// <summary>
        /// Core Logical method - helps to run the game 1 round and checks if game is completed to increment the set
        /// </summary>
        /// <param name="playerSetWinner"></param>
        /// <param name="playerSetLooser"></param>
        private void CalculateNewPoints(IPlayerSet playerSetWinner, IPlayerSet playerSetLooser)
        {
            _game.CurrentPointWinner(playerSetWinner.Player);

            if (!_game.IsGameCompleted) return;

            playerSetWinner.Score++;

            //If a player reach the Set score of 6 and the other player has a Set score of 4 or lower, the player win the Set
            if ((playerSetWinner.Score == 6 && playerSetLooser.Score <= 4)
                || (playerSetWinner.Score == 7 && playerSetLooser.Score < playerSetWinner.Score))
            {
                Winner = playerSetWinner.Player;
                return;
            }

            CreateGame();

        }

        
    }
}
