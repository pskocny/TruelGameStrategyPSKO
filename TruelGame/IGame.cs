using System;
using System.Collections.Generic;
using System.Text;

namespace TruelGame
{
    /// <summary>
    /// Strategy choices
    /// </summary>
    public enum TruelStrategy { Weaknest, Strongest, StrongestToAir};

    /// <summary>
    /// Game interface
    /// </summary>
    public interface IGame
    {
        /// <summary>
        /// Add player to the game
        /// </summary>
        /// <param name="player">Player instance to add</param>
        void AddPlayer(IPlayer player);
        /// <summary>
        /// Remove player from the game
        /// </summary>
        /// <param name="player">Player instance to remove</param>
        void RemovePlayer(IPlayer player);

        /// <summary>
        /// Play game by given strategy
        /// </summary>
        /// <param name="strategy">Strategy</param>
        void PlayGame(TruelStrategy strategy);

        /// <summary>
        /// Return winner
        /// </summary>
        /// <returns>Winner</returns>
        IPlayer GetWinner();
    }
}
