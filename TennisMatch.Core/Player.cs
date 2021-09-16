using System;
using TennisMatch.Core.Interfaces;

namespace TennisMatch.Core
{
    public class Player: IPlayer
    {
        public Player(string player)
        {
            Name = player;
        }

        public string Name { get; set; }
    }
}
