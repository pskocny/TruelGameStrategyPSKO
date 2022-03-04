using System;
using System.Collections.Generic;
using System.Text;

namespace TruelGame
{
    public class Player : IPlayer
    {
        
        public string PlayerName { get; }
       
        public double Performance { get; }

        public Random RandomGenerator { get; }

        public Player(string playerName, double performance, Random randomGenerator) 
        { 
            PlayerName = playerName;
            Performance = performance;
            RandomGenerator = randomGenerator;
        }
        public event EventHandler<PlayerHitEventArgs> PlayerHit;

        
        public bool Play(IPlayer target)
        {
            if (RandomGenerator.NextDouble() <= Performance)
            {
                // Invoke event, that target player was hitted
                PlayerHit?.Invoke(this, new PlayerHitEventArgs(target));
                return true;
            }
            return false;
        }
    }
}
