using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TruelGame
{
    public class GameList : IGame
    {
        private readonly List<IPlayer> Players;
        private int currentTurn;
        private IPlayer firstPlayer;

        public GameList()
        {
            Players = new List<IPlayer>();
            currentTurn = 0;
        }
        public void AddPlayer(IPlayer player)
        {
            if (Players.Count == 0)
            {
                firstPlayer = player;
            }
            Players.Add(player);

            player.PlayerHit += (s, e) => Players.Remove(e.Target);
        }

        
        public IPlayer GetWinner()
        {
            return Players[0];
        }

        public void PlayGame(TruelStrategy strategy)
        {
            // Play until all players except one is killed
            while (Players.Count >= 2)
            {
                // Skip first player if there are more than 2 players
                if (Players.Count > 2 
                    && strategy == TruelStrategy.StrongestToAir
                    && GetCurrentTurnPlayer() == this.firstPlayer)
                {
                    NextTurn();
                }

                IPlayer currentTurnPlayer = GetCurrentTurnPlayer();
                currentTurnPlayer.Play(GetSecondPlayer(currentTurnPlayer, strategy));

                NextTurn();
            }
        }

        public void RemovePlayer(IPlayer player)
        {
            Players.Remove(player);
        }

        private void NextTurn()
        {
            currentTurn++;
            if (currentTurn >= Players.Count)
            {
                currentTurn = 0;
            }
        }

        private IPlayer GetCurrentTurnPlayer()
        {
            return Players[currentTurn];
        }

        private IPlayer GetSecondPlayer(IPlayer firstPlayer, TruelStrategy strategy)
        {
            IPlayer secondPlayer = null;
            var playersWithoutFirst = Players.Where(p => p != firstPlayer).ToList();
            
            if (strategy == TruelStrategy.Weaknest)
            {
                secondPlayer = playersWithoutFirst.OrderBy(p => p.Performance).First();
            }
            else if (strategy == TruelStrategy.Strongest || strategy == TruelStrategy.StrongestToAir)
            {
                secondPlayer = playersWithoutFirst.OrderByDescending(p => p.Performance).First();
            }
            
            return secondPlayer;
        }
    }
}
