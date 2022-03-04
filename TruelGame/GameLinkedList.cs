using System;
using System.Collections.Generic;
using System.Text;

namespace TruelGame
{
    public class GameLinkedList : IGame
    {
        private readonly LinkedList<IPlayer> Players;
        private LinkedListNode<IPlayer> currentTurn;
        private LinkedListNode<IPlayer> secondPlayerNode;
        private IPlayer firstPlayer;

        public GameLinkedList()
        {
            Players = new LinkedList<IPlayer>();
            
        }
        public void AddPlayer(IPlayer player)
        {
            Players.AddLast(player);
            if (Players.Count == 1)
            {
                firstPlayer = player;
                currentTurn = Players.Last;
            }

            //player.PlayerHit += OnPlayerHit;    
           // player.PlayerHit += (s, e) => Players.Remove(e.Target);
        }

        private void OnPlayerHit(object sender, PlayerHitEventArgs e)
        {
            RemovePlayer(e.Target);
        }

        public IPlayer GetWinner()
        {
            return Players.First.Value;
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
                IPlayer secondPlayer = GetSecondPlayer(currentTurnPlayer, strategy);
                if (currentTurnPlayer.Play(secondPlayer))
                {
                    Players.Remove(secondPlayer);
                }

                NextTurn();
            }
        }

        public void RemovePlayer(IPlayer player)
        {
            if (player == secondPlayerNode.Value)
            {
                Players.Remove(secondPlayerNode);
            }
            else
            {
                Players.Remove(player);
            }
        }

        private void NextTurn()
        {
            currentTurn = currentTurn.Next;

            if (currentTurn == null)
            {
                currentTurn = Players.First;
            }
        }

        private IPlayer GetCurrentTurnPlayer()
        {
            return currentTurn.Value;
        }

        private IPlayer GetSecondPlayer(IPlayer firstPlayer, TruelStrategy strategy)
        {
            IPlayer secondPlayer = null;
            for (var playerNode = Players.First; playerNode != null; playerNode = playerNode.Next)
            {
                if (playerNode.Value == firstPlayer)
                    continue;


                if (strategy == TruelStrategy.Weaknest)
                {
                    if ( secondPlayer == null || secondPlayer.Performance > playerNode.Value.Performance)
                    {
                        secondPlayer = playerNode.Value;
                        secondPlayerNode = playerNode;
                    }
                }
                else if (strategy == TruelStrategy.Strongest || strategy == TruelStrategy.StrongestToAir)
                {
                    if (secondPlayer == null || secondPlayer.Performance < playerNode.Value.Performance)
                    {
                        secondPlayer = playerNode.Value;
                        secondPlayerNode = playerNode;

                    }
                }
            }

            if (secondPlayer == null)
            {
                secondPlayer = firstPlayer;
            }
            
            return secondPlayer;
        }
    }
}
