using System;
using System.Collections.Generic;
using System.Text;

namespace TruelGame
{
    public interface IPlayer
    {
        /// <summary>
        /// Player name
        /// </summary>
        string PlayerName { get; }

        /// <summary>
        /// Performance from interval <0,1>
        /// </summary>
        double Performance { get; }

        Random RandomGenerator { get; }

        /// <summary>
        /// Play game
        /// </summary>
        /// <param name="target">Counter player</param>
        /// <returns></returns>
        bool Play(IPlayer target);

        /// <summary>
        /// Target hit event 
        /// </summary>
        public event EventHandler<PlayerHitEventArgs> PlayerHit;
    }
}
