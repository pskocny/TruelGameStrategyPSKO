using System;

namespace TruelGame
{
    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            IPlayer playerBlack = new Player("Black", 1.0 / 3, rand);
            IPlayer playerDark = new Player("Dark", 2.0 / 3, rand);
            IPlayer playerWhite = new Player("White", 1.0, rand);
            int noOfBlackWin = 0;

            for (int i = 0; i < 1000000; i++)
            {
                IGame game = new GameLinkedList();
                game.AddPlayer(playerBlack);
                game.AddPlayer(playerDark);
                game.AddPlayer(playerWhite);
                //Console.WriteLine("Game started");
                game.PlayGame(TruelStrategy.Strongest);
                //Console.WriteLine("Winner is " + game.GetWinner().PlayerName);
                if (game.GetWinner().PlayerName.Equals(playerBlack.PlayerName))
                {
                    noOfBlackWin++;
                }
            }
            Console.WriteLine(noOfBlackWin);
            noOfBlackWin = 0;
            for (int i = 0; i < 1000000; i++)
            {
                IGame game = new GameLinkedList();
                game.AddPlayer(playerBlack);
                game.AddPlayer(playerDark);
                game.AddPlayer(playerWhite);
                //Console.WriteLine("Game started");
                game.PlayGame(TruelStrategy.StrongestToAir);
                //Console.WriteLine("Winner is " + game.GetWinner().PlayerName);
                if (game.GetWinner().PlayerName.Equals(playerBlack.PlayerName))
                {
                    noOfBlackWin++;
                }
            }
            Console.WriteLine(noOfBlackWin);

        }
    }
}
