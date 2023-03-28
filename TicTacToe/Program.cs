using System;

namespace TicTacToe
{
    internal class Program
    {
        static int[,] board = new int[3, 3];
        static bool winner = false;
        static void Main(string[] args)
        {
            // Continue to play/run until a Player wins
            while (!winner) 
            {
                Player1();
                Player2();
            }
        }

        // Player 1 Method everything The Player would do during their turn
        public static void Player1()
        {
            ShowBoard();
            Placement(1);
            winner = CheckWinner(1);
        }
        // Player 2 Method everything The Player would do during their turn
        public static void Player2()
        {
            ShowBoard();
            Placement(2);
            winner = CheckWinner(2);
        }

        /// <summary>
        /// Placing the players tic on the board. Putting the player given, into the array at the input given
        /// </summary>
        /// <param name="player"></param>
        public static void Placement(int player)
        {
            bool placementInProgress = true;
            while (placementInProgress)
            {
                Console.WriteLine("What Column: ");
                Int32.TryParse(Console.ReadLine(), out int column);
                Console.WriteLine("What Row: ");
                Int32.TryParse(Console.ReadLine(), out int row);

                if(row >= 0 && row <= 2 && column >= 0 && column <= 2)
                { 
                    if (board[column, row].Equals(0))
                    {
                        board[column, row] = player;
                        placementInProgress = false;
                    }
                    else
                    {
                        Console.WriteLine("Spot taken, pick a differnt spot");
                    }
                }
                else
                {
                    Console.WriteLine("Thats not a space on the board");
                }
            }
        }

        /// <summary>
        /// Displays the array in the console in a rough board.
        /// </summary>
        public static void ShowBoard()
        {
            Console.WriteLine("++++++++++++++++++");
            for (int i = 0;  i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i,j] != 0)
                    {
                        Console.Write("|" + board[i, j] + "|");
                    }
                    else
                    {
                        Console.Write("| |");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("++++++++++++++++++");
        }

        /// <summary>
        /// Checking if there is 3 line placed by one player. If so it returns True else False.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool CheckWinner(int player)
        {
            // Check Across the top
            if (board[0, 0].Equals(player) && board[0, 1].Equals(player) && board[0, 2].Equals(player))
            {
                Console.WriteLine("Winner is player: " + board[0, 0]);
                return true;
            }
            // Check Down the left side
            else if (board[0, 0].Equals(player) && board[1, 0].Equals(player) && board[2, 0].Equals(player))
            {
                Console.WriteLine("Winner is player: " + board[0, 0]);
                return true;
            }
            // Check Top left to Bottom Right
            else if (board[0, 0].Equals(player) && board[1, 1].Equals(player) && board[2, 2].Equals(player))
            {
                Console.WriteLine("Winner is player: " + board[0, 0]);
                return true;
            }
            // Check Bottom left to Top Right
            else if (board[2, 0].Equals(player) && board[1, 1].Equals(player) && board[0, 2].Equals(player))
            {
                Console.WriteLine("Winner is player: " + board[2, 0]);
                return true;
            }
            // Check Across the Bottom
            else if (board[2, 0].Equals(player) && board[2, 1].Equals(player) && board[2, 2].Equals(player))
            {
                Console.WriteLine("Winner is player: " + board[2, 0]);
                return true;
            }
            // Check Down the Right side
            else if (board[0, 2].Equals(player) && board[1, 2].Equals(player) && board[2, 2].Equals(player))
            {
                Console.WriteLine("Winner is player: " + board[0, 2]);
                return true;
            }
            else
            {
                return false;
            }

        }
         
    }
}
