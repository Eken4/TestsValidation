using MorpionApp.Controller;
using MorpionApp.Models;

namespace MorpionApp
{
    public class Morpion : Game
    {
        public Morpion() :
            base(new Grid(3, 3))
        { }


        public override void GameLoop()
        {
            while (!exitGame)
            {
                while (!exitGame)
                {
                    if (playerTurn)
                    {
                        PlayerTurn('X');
                        if (CheckVictory('X'))
                        {
                            EndGame("Le joueur 1 a gagné !");
                            break;
                        }
                    }
                    else
                    {
                        PlayerTurn('O');
                        if (CheckVictory('O'))
                        {
                            EndGame("Le joueur 2 a gagné !");
                            break;
                        }
                    }
                    playerTurn = !playerTurn;
                    if (CheckTie())
                    {
                        EndGame("Aucun vainqueur, la partie se termine sur une égalité.");
                        break;
                    }
                }
                if (!exitGame)
                {
                    Console.WriteLine("Appuyer sur [Echap] pour quitter, [Entrée] pour rejouer.");
                GetKey:
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Enter:
                            break;
                        case ConsoleKey.Escape:
                            exitGame = true;
                            Console.Clear();
                            break;
                        default:
                            goto GetKey;
                    }
                }

            }
        }

        public override bool CheckVictory(char c) =>
             grid.GetCase(0, 0) == c && grid.GetCase(1, 0) == c && grid.GetCase(2, 0) == c ||
             grid.GetCase(0, 1) == c && grid.GetCase(1, 1) == c && grid.GetCase(2, 1) == c ||
             grid.GetCase(0, 2) == c && grid.GetCase(1, 2) == c && grid.GetCase(2, 2) == c ||
             grid.GetCase(0, 0) == c && grid.GetCase(1, 0) == c && grid.GetCase(2, 0) == c ||
             grid.GetCase(1, 0) == c && grid.GetCase(1, 1) == c && grid.GetCase(1, 2) == c ||
             grid.GetCase(2, 0) == c && grid.GetCase(2, 1) == c && grid.GetCase(2, 2) == c ||
             grid.GetCase(0, 0) == c && grid.GetCase(1, 1) == c && grid.GetCase(2, 2) == c ||
             grid.GetCase(2, 0) == c && grid.GetCase(1, 1) == c && grid.GetCase(0, 2) == c;

        public override bool CheckTie() =>
            grid.GetCase(0, 0) != ' ' && grid.GetCase(1, 0) != ' ' && grid.GetCase(2, 0) != ' ' &&
            grid.GetCase(0, 1) != ' ' && grid.GetCase(1, 1) != ' ' && grid.GetCase(2, 1) != ' ' &&
            grid.GetCase(0, 2) != ' ' && grid.GetCase(1, 2) != ' ' && grid.GetCase(2, 2) != ' ';


    }
}
