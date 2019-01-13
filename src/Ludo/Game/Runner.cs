using System;
using System.Collections.Generic;
using System.Text;
using Ludo.Engine;

namespace Ludo.Game
{
    class Runner
    {
        public static void Start(string[] args)
        {
            Board TheBoard = new Board();

            Console.WriteLine("Ludo game can be played by 2 to 4 players. Please enter the number of players:");

            int NumberOfPlayers = ReadPlayerNumber();

            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Console.WriteLine("Please enter the color for your player (you may enter red, yellow, blue or green):");

                string PlayerColor = Console.ReadLine();

                Player P = new Player();
                P.color = PlayerColor;
                TheBoard.AddPlayer(P);
            }

            Console.WriteLine("Starting the game now");


            Dice dice = new Dice();

            while (true)
            {
                Player player = TheBoard.GetCurrentPlayer();
                int diceroll = dice.Roll();
                Console.WriteLine("Player " + player.color + " rolled the dice ang got this number: " + diceroll);
                player.ShowInfo();

                while (true)
                {
                    if (player.CanPutPieceInPlay(diceroll))
                    {
                        Console.WriteLine("Would you like to put a new piece on the board? Enter the number of the piece or 'no'");
                        {
                            string answer = Console.ReadLine();
                            if (answer == "") { }
                            else if (answer != "no")
                            {
                                int choice = int.Parse(answer);
                                player.MovePieceOntoBoard(choice - 1);
                                break;
                            }
                        }
                    }

                    if (player.CanMoveAnyPieces(diceroll))
                    {
                        Console.WriteLine("Which piece would you like to move? Please enter its number: ");
                        int readpiecenumber = ReadPieceNumber() - 1;
                        if (player.CanMovePiece(readpiecenumber, diceroll))
                        {
                            player.PlayerMovePiece(readpiecenumber, diceroll);
                            break;
                        }
                    }

                    else break;
                }

                if (player.Won())
                {
                    Console.WriteLine("Game Over! PLayer " + player.color + " has won!");
                    break;
                }
                TheBoard.NextTurn();
            }
            Console.ReadLine();
        }

        static public int ReadPieceNumber()
        {
            while (true)
            {
                string fromuser = Console.ReadLine();

                if (fromuser == "1" || fromuser == "2" || fromuser == "3" || fromuser == "4")
                {
                    return int.Parse(fromuser);
                }
                else
                {
                    Console.WriteLine("Error in input. Please try again.");
                }
                
            }
        }

        static public int ReadPlayerNumber()
        {
            while (true)
            {
                string fromuser = Console.ReadLine();

                if (fromuser == "2" || fromuser == "3" || fromuser == "4")
                {
                    return int.Parse(fromuser);
                }
                else
                {
                    Console.WriteLine("Error in input. Please try again.");
                }

            }
        }
    }
    
}
