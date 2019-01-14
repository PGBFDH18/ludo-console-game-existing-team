using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace GameEngine
{

    //CRITCAL BUG:::::: Loop does not display die rolls
    //Bug when coloring console.foreground

    public class GameFlow
    {
        
        List<Player> Players = new List<Player>();

        int playerCount = 0;

        bool running = true;

        Dictionary<int, string> Colors = new Dictionary<int, string>()
        {
            {1,"Blue"},
            { 2,"Yellow"},
            { 3,"Red"},
            { 4,"Green"}
        };

        private int DecideColor(Dictionary<int,string> ColorAlternative)
        {
            
            foreach(KeyValuePair<int,string> pair in Colors)
            {
                Console.WriteLine($"{pair.Key}. {pair.Value}");
            }
            
            int option = int.Parse(Console.ReadLine().ToString());

            Console.Clear();

            return option;

        }

        private int dieRoll()
        {
           
             Random rand = new Random();

             int dieRoll = rand.Next(1, 7);

             if (dieRoll == 6)
             {
                 dieRoll += rand.Next(1, 7);
             }

            return dieRoll;
            
        }

        private void rolled1(Player currentPlayer)
        {
            bool validoption = false;
            do
            {
                Console.WriteLine("Do you want to: \n 1.Move piece from fence to board space 1 \n 2." +
                                  "Move piece 1 space");

                int pick = int.Parse(Console.ReadLine().ToString());

                if (pick == 1)
                {
                    currentPlayer.ChosePieceFromFence(1);
                    validoption = true;
                }
                else if (pick == 2)
                {
                    currentPlayer.ChosePieceMove(1);
                    validoption = true;
                }
                else
                {
                    Console.WriteLine("ERROR: You have to pick a valid option");
                }
            } while (!validoption);
        }
        private void rolled6(Player currentPlayer)
        {
            bool validOption = false;

            do
            {
                Console.WriteLine($"Do you want to: \n 1. Move two pieces from fence to board space 1 \n" +
                $"2. Move one piece from fence to board space 6 \n 3. Move one piece 6 spaces");

                int pick = int.Parse(Console.ReadLine());



                if (pick == 1)
                {
                    currentPlayer.ChosePieceFromFence(1);
                    currentPlayer.ChosePieceFromFence(1);

                    validOption = true;
                }
                else if (pick == 2)
                {
                    currentPlayer.ChosePieceFromFence(6);
                    validOption = true;
                }
                else if (pick == 3)
                {
                    currentPlayer.ChosePieceMove(6);
                    validOption = true;
                }
                else
                {
                    Console.WriteLine("ERROR: INVALID INPUT");
                }
            } while (!validOption);
        }
        private void rolledAbove6(Player currentPlayer)
        {
            Console.WriteLine($"Your rolled a 6 and therefore got the oppertunity to roll again \n" +
                                    $"Please pick an alternative: \n 1. Move two pieces from fence to board space 1 \n" +
                                $"2. Move one piece from fence to board space 6 \n 3. Move one piece 6 spaces");

            int pick = int.Parse(Console.ReadLine().ToString());

            bool validOption = false;
            do

            {


                if (pick == 1)
                {
                    currentPlayer.ChosePieceFromFence(1);
                    currentPlayer.ChosePieceFromFence(1);

                    validOption = true;
                }
                else if (pick == 2)
                {
                    currentPlayer.ChosePieceFromFence(6);
                    validOption = true;
                }
                else if (pick == 3)
                {
                    currentPlayer.ChosePieceMove(6);
                    validOption = true;
                }
                else
                {
                    Console.WriteLine("ERROR: INVALID INPUT");
                }
            } while (!validOption);
        }

        private int Init()
        {

            Console.WriteLine(Colors.Count);

            Console.WriteLine("Hello and welcome to ludo \n How many players want to play? \n 2. \n 3. \n 4.");

            playerCount = int.Parse(Console.ReadLine().ToString());

            if (playerCount != 2 && playerCount != 3 && playerCount != 4)
            {
                Console.WriteLine("ERROR: invalid key input");
                return -1;
            }

            for (int i = 0; i < playerCount; i++)
            {
                int temp = 0;
                foreach(Player p in Players)
                {
                    
                    Console.WriteLine($"{p.turnOrder}. {p.name}: Color is {p.color}");
                }

                Console.WriteLine($"Please the name of player {i+1}: ");
                string tempPlayerName = Console.ReadLine();



                bool keyFound = false;

                do
                {
                    int pickedColor = DecideColor(Colors);
                    try
                    {
                        Players.Add(new Player(tempPlayerName, Colors[pickedColor], i + 1));
                        Colors.Remove(pickedColor);
                        keyFound = true;
                    }
                    catch (KeyNotFoundException e)
                    {
                        Console.WriteLine("Error you have to pick a available keyvalue");
                    }

                } while (!keyFound);

                
                
            }
            return 0;
        }


        public GameFlow()
        {
            Init();

            int round = 1;

            while (running)
            {
                gameRound(round);
                round++;
            }

            Console.WriteLine($"Shutting down...");

        }

        private void gameRound(int round)
        {
            
            Console.WriteLine($"ROUND: {round}");

            Player[] PlayersByTurnOrder = Players.OrderBy(x => x.turnOrder).ToArray<Player>();
            
           
            for(int i = 0; i < PlayersByTurnOrder.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;


                Console.WriteLine($"{PlayersByTurnOrder[i].name}'s turn! \n Roll DIE...");
                Console.ReadKey();

                
                Player currentPlayer = PlayersByTurnOrder[i];
                
                int dieResult = dieRoll();

                
                Console.WriteLine($"Your rolled {dieResult}");
                
                switch(dieResult)
                {
                    case 1:
                        {
                            rolled1(currentPlayer);
                            break;
                        }

                    case 6:
                        {
                            rolled6(currentPlayer);
                            break;
                        }

                    default:
                        {

                            if (dieResult > 6)
                            {
                                rolledAbove6(currentPlayer);
                            }
                            else
                            {
                                Console.WriteLine($"Chose which piece you would like to move {dieResult} spaces");
                                currentPlayer.ChosePieceMove(dieResult);
                            }
                            
                            break;
                        }
 
                }

                Console.Clear();

                if(PlayersByTurnOrder[i].score == 4)
                {
                    Console.WriteLine($"Congratulations, {PlayersByTurnOrder[i]} is the winner!");
                    running = false;
                }


            }

            
        }

    }
}
