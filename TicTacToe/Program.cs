using System;

namespace TicTacToe
{
    internal class Program
    {
        static char[,] board = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
        static int tacPlaced = 0;
        static bool winner = false;

        // Ascii Number for X
        static char player1Marker = 'X';

        // Ascii Number for O
        static char player2Marker = 'O';

        static void Main(string[] args)
        {
            Gameloop();
        }

        /// <summary>
        /// Resets the Game, Clears the board array, resets winner, and resets the possibility of a cats game.
        /// </summary>
        public static void ResetGame()
        {
            int counter = 0;

            // Info for Users & waiting for them to play another game
            Console.WriteLine("Press anything to play again");
            Console.ReadKey();
            Console.Clear();

            // Resetting the game
            winner = false;
            tacPlaced = 0;
            
            // Resetting the board
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    counter++;
                    string sCounter = counter.ToString();
                    board[i,j] = char.Parse(sCounter);
                }
            }

            //Start New Game
            Gameloop();
        }

        public static void Gameloop()
        {
            initSetup();
            // Continue to play/run until a Player wins
            while (!winner)
            {
                // Player 1
                ShowBoard();
                Placement(player1Marker);
                winner = CheckWinner(player1Marker);
                if (winner)
                {
                    Console.Clear();
                    ShowBoard();
                    Console.WriteLine("Player 1 is the Winner!");
                    break;
                }
                else if (tacPlaced == 9)
                {
                    Console.Clear();
                    ShowBoard();
                    Console.WriteLine("Cats Game");
                    break;

                }
                Console.Clear();

                // Player 2
                ShowBoard();
                Placement(player2Marker);
                winner = CheckWinner(player2Marker);
                if (winner)
                {
                    Console.WriteLine("Player 2 is the Winner!");
                    break;
                }
                else if (tacPlaced == 9)
                {
                    Console.WriteLine("Cats Game");
                    break;

                }
                Console.Clear();

            }
            ResetGame();
        }


        /// <summary>
        /// Placing the players tic on the board. Putting the player given, into the array at the input given
        /// </summary>
        /// <param name="player"></param>
        public static void Placement(char player)
        {
            // Run will the user is placing their tic
            bool placementInProgress = true;
            while (placementInProgress)
            {
                // Telling the player to enter their input
                Console.WriteLine($"{player}, Pick a Spot thats Open: ");
                string userInput = Console.ReadLine();

                // If the 
                if (char.TryParse(userInput, out char position))
                {
                    for (int i = 0; i < board.GetLength(0); i++)
                    {
                        for (int j = 0; j < board.GetLength(1); j++)
                        {
                            if (board[i, j] == position)
                            {
                                board[i, j] = player;
                                placementInProgress = false;
                                tacPlaced++;
                            }
                            else
                            {
                                Console.WriteLine("Not a vaild input");
                            }
                        }
                    }

                }

            }
            
        }

        /// <summary>
        /// Displays the array in the console in a rough board.
        /// </summary>
        public static void ShowBoard()
        {

            Console.WriteLine("       |       |      ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", Convert.ToChar(board[0, 0]), Convert.ToChar(board[0, 1]), Convert.ToChar(board[0, 2]));
            Console.WriteLine("       |       |      ");
            Console.WriteLine("----------------------");
            Console.WriteLine("       |       |      ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", Convert.ToChar(board[1, 0]), Convert.ToChar(board[1, 1]), Convert.ToChar(board[1, 2]));
            Console.WriteLine("       |       |      ");
            Console.WriteLine("----------------------");
            Console.WriteLine("       |       |      ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", Convert.ToChar(board[2, 0]), Convert.ToChar(board[2, 1]), Convert.ToChar(board[2, 2]));
            Console.WriteLine("       |       |      ");


        }

        /// <summary>
        /// Checking if there is 3 line placed by one player. If so it returns True else False.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static bool CheckWinner(char player)
        {

            // Check Across the top
            if (board[0, 0].Equals(player) && board[0, 1].Equals(player) && board[0, 2].Equals(player))
            {
                return true;
            }
            // Check Down the left side
            else if (board[0, 0].Equals(player) && board[1, 0].Equals(player) && board[2, 0].Equals(player))
            {
                return true;
            }
            // Check Top left to Bottom Right
            else if (board[0, 0].Equals(player) && board[1, 1].Equals(player) && board[2, 2].Equals(player))
            {
                return true;
            }
            // Check Bottom left to Top Right
            else if (board[2, 0].Equals(player) && board[1, 1].Equals(player) && board[0, 2].Equals(player))
            {
                return true;
            }
            // Check Across the Bottom
            else if (board[2, 0].Equals(player) && board[2, 1].Equals(player) && board[2, 2].Equals(player))
            {
                return true;
            }
            // Check Down the Right side
            else if (board[0, 2].Equals(player) && board[1, 2].Equals(player) && board[2, 2].Equals(player))
            {
                return true;
            }
            // Check Across the Middle
            else if (board[1, 0].Equals(player) && board[1, 1].Equals(player) && board[1, 2].Equals(player))
            {
                return true;
            }
            // Check down the Middle
            else if (board[0, 1].Equals(player) && board[1, 1].Equals(player) && board[2, 1].Equals(player))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void initSetup()
        {

            Console.Title = "Tic Tac Toe: by Myles";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
         
    }
}
