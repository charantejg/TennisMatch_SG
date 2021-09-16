using System.Reflection.PortableExecutable;
using NUnit.Framework;
using TennisMatch.Core;
using TennisMatch.Core.Interfaces;

namespace TennisMatch.Tests
{
    
    public class MatchSetsTest
    {
        private IPlayer _playerA;
        private IPlayer _playerB;
        private ISet _set;

        [SetUp]
        public void Setup()
        {
            // Init two players and start the set
            // internally creates two player set and starts a new Game 
            _playerA = new Player("Player A");
            _playerB = new Player("Player B");
            _set = new Set(_playerA, _playerB);

        }

        [Test]
        public void PlayerAWinsAll_Test()
        {
            // 6 sets , 4 rounds
            AutoIncrementSet(24,_playerA);
           
            var currentGameScore = _set.DisplayScoreBoard(_playerA).Split(",");
            Assert.AreEqual($"{currentGameScore[0]},6", $"{currentGameScore[0]},{currentGameScore[1]}");
            Assert.True(_set.SetEnd);
        }


        [Test]
        public void PlayerBWinsAll_Test()
        {
            AutoIncrementSet(24, _playerB);

            var currentGameScore = _set.DisplayScoreBoard(_playerB).Split(",");
            Assert.AreEqual($"{currentGameScore[0]},6", $"{currentGameScore[0]},{currentGameScore[1]}");
            Assert.True(_set.SetEnd);
        }


        [Test]
        public void PlayerAWinsSixSet_PlayerBWinsFourSet_Test()
        {
            // 5 sets
            AutoIncrementSet(20, _playerA);
            // 4 sets
            AutoIncrementSet(16, _playerB);
            // 1 set
            AutoIncrementSet(4, _playerA);
            
            var currentGameScore = _set.DisplayScoreBoard(_playerA).Split(",");
            Assert.AreEqual($"{currentGameScore[0]},6", $"{currentGameScore[0]},{currentGameScore[1]}");

            currentGameScore = _set.DisplayScoreBoard(_playerB).Split(",");
            Assert.AreEqual($"{currentGameScore[0]},4", $"{currentGameScore[0]},{currentGameScore[1]}");

            Assert.True(_set.SetEnd);

        }


        private void AutoIncrementSet(int times, IPlayer player)
        {
            for (var i = 0; i < times; i++)
            {
                _set.CurrentPointWinner(player);
            }
        }
    }
}