using MorpionApp.Models;

namespace MorpionApp.Controller
{
    public abstract class Game
    {
        protected bool exitGame = false;
        protected bool playerTurn = true;
        protected Grid grid;

        public Game(Grid gameGrid)
        {
            grid = gameGrid;
        }

        public abstract void GameLoop();

        public void PlayerTurn(char token)
        {
            var (row, column) = (0, 0);
            bool moved = false;

            while (!exitGame && !moved)
            {
                Console.Clear();
                DisplayGrid();
                Console.WriteLine();
                Console.WriteLine("Choisir une case valide et appuyer sur [Entrée]");
                Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        exitGame = true;
                        Console.Clear();
                        break;

                    case ConsoleKey.RightArrow:
                        if (column >= 2) //grid.GetCase(cursorPosition).IsRightEdge()
                        {
                            column = 0;
                        }
                        else
                        {
                            column = column + 1;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (column <= 0)
                        {
                            column = grid.Width;
                        }
                        else
                        {
                            column = column - 1;
                        }
                        break;

                    case ConsoleKey.UpArrow:
                        if (row <= 0)
                        {
                            row = grid.Height;
                        }
                        else
                        {
                            row = row - 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (row >= 2)
                        {
                            row = 0;
                        }
                        else
                        {
                            row = row + 1;
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (grid.GetCase(row, column) is ' ')
                        {
                            grid.SetCase(row, column, token);
                            moved = true;
                            exitGame = false;
                        }
                        break;
                }

            }
        }
        public void DisplayGrid()
        {
            for (int i = 0; i < grid.Height; i++)
            {
                for (int j = 0; j < grid.Width; j++)
                {
                    Console.Write($" {grid.GetCase(i, j)} ");
                    if (j < grid.Width - 1)
                    {
                        Console.Write("|");
                    }
                }
                if (i < grid.Height - 1)
                {
                    Console.WriteLine(new string('-', grid.Width * 4 - 1));
                }

            }
        }

        public abstract bool CheckVictory(char c);
        public abstract bool CheckTie();
        public void EndGame(string msg)
        {
            Console.Clear();
            DisplayGrid();
            Console.WriteLine(msg);
        }
    }
}
