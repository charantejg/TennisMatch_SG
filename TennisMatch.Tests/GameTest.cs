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

        [Test]
        public void Fifteen_Each()
        {
            _game.CurrentPointWinner(_playerA);
            _game.CurrentPointWinner(_playerB);
            ResultShouldBe($"{_playerA.Name}:15,{_playerB.Name}:15");
        }

        [Test]
        public void FirstPlayerWinAllPoints_Test()
        {
           AutoIncrement(4,_playerA);
           ResultShouldBe($"{_playerA.Name} wins the game point");
           Assert.True(_game.IsGameCompleted);

        }

        [Test]
        public void SecondPlayerWinAllPoints_Test()
        {
            AutoIncrement(4, _playerB);
            ResultShouldBe($"{_playerB.Name} wins the game point");
            Assert.True(_game.IsGameCompleted);

        }

        [Test]
        public void FirstPlayerWinWithMorePoints_Test()
        {
            AutoIncrement(4, _playerA);
            AutoIncrement(2, _playerB);
            ResultShouldBe($"{_playerA.Name} wins the game point");
            Assert.True(_game.IsGameCompleted);

        }

        [Test]
        public void DeuceTest()
        {
            AutoIncrement(3, _playerA);
            AutoIncrement(3, _playerB);
            ResultShouldBe($"{_playerA.Name}:40,{_playerB.Name}:40");
           
        }


        private void ResultShouldBe(string expected)
        {
            // checking if the user expected result matching with the game scoreboard
            
            Assert.AreEqual(expected, _game.GameScoreBoard());
        }

        private void AutoIncrement(int times, IPlayer player)
        {
            for (var i = 0; i < times; i++)
            {
                _game.CurrentPointWinner(player);
            }
        }
    }
}