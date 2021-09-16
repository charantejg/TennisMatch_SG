using NUnit.Framework;
using TennisMatch.Core;
using TennisMatch.Core.Interfaces;

namespace TennisMatch.Tests
{
    public class GameTest
    {
        private IPlayer _playerA;
        private IPlayer _playerB;
        private IGame _game;

        [SetUp]
        public void Setup()
        {
            // Init two players and start the game 
            _playerA = new Player("Player A");
            _playerB = new Player("Player B");
            _game = new Game(_playerA, _playerB);

        }

        [Test]
        public void Love_All()
        {
            // Begin of the game default score starts at zero for both players
            ResultShouldBe($"{_playerA.Name}:0,{_playerB.Name}:0");
        }

        [Test]
        public void Fifteen_Love()
        {
            _game.CurrentPointWinner(_playerA);
            ResultShouldBe($"{_playerA.Name}:15,{_playerB.Name}:0");
        }
        
        private void ResultShouldBe(string expected)
        {
            // checking if the user expected result matching with the game scoreboard
            
            Assert.AreEqual(expected, _game.GameScoreBoard());
        }
    }
}