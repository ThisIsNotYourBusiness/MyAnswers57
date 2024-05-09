using System;
using System.Collections.Generic;
using System.Text;

namespace _2048game
{

    class ConsoleGame 
    {
        private Game game;


        private static void PrintCenter(string s)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (s.Length / 2)) + "}", s));
        }

        private static void PrintGame(Game game)
        {
            Console.Clear();


            PrintCenter("POINTS: " + game.Points);
            PrintCenter("======================================================");

            for (int row = 0; row < game.Board.Data.GetLength(0); row++)
            {
                StringBuilder builder = new StringBuilder();
                PrintCenter("= -----------  -----------  -----------  ----------- =");
                PrintCenter("= |         |  |         |  |         |  |         | =");
                for (int col = 0; col < game.Board.Data.GetLength(1); col++)
                {
                    if (game.Board.Data[row, col] != null)
                        builder.Append(" " + game.Board.Data[row, col].ToString() + " ");
                    else
                        builder.Append(" " + Tile.GetTileString(0) + " ");
                }
                PrintCenter("=" + builder.ToString() + "=");
                PrintCenter("= |         |  |         |  |         |  |         | =");
                PrintCenter("= -----------  -----------  -----------  ----------- =");
            }

            PrintCenter("======================================================");
            PrintCenter("=======");
            PrintCenter("|  W  |");
            PrintCenter("=======");
            PrintCenter("=======  =======  =======");
            PrintCenter("|  A  |  |  S  |  |  D  |");
            PrintCenter("=======  =======  =======");
        }
        public void Start()
        {
            game = new Game();

            while (game.Status == GameStatus.Idle)
            {

                PrintGame(game);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.W:
                        game.Move(Direction.Up);
                        break;

                    case ConsoleKey.UpArrow:
                        game.Move(Direction.Up);
                        break;

                    case ConsoleKey.A:
                        game.Move(Direction.Left);
                        break;

                    case ConsoleKey.LeftArrow:
                        game.Move(Direction.Left);
                        break;

                    case ConsoleKey.S:
                        game.Move(Direction.Down);
                        break;

                    case ConsoleKey.DownArrow:
                        game.Move(Direction.Down);
                        break;

                    case ConsoleKey.D:
                        game.Move(Direction.Right);
                        break;

                    case ConsoleKey.RightArrow:
                        game.Move(Direction.Right);
                        break;

                    default:
                        break;

                }

                if (game.Status == GameStatus.Lose)
                {
                    PrintGame(game);
                    PrintCenter("======================================================");
                    PrintCenter("YOU LOSE!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.ReadKey();
                    game = null;
                    Start();
                }

            }

            

        }

    }
}
