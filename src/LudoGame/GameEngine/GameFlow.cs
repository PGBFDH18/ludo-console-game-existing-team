using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine
{
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

            gameRound();

            while(running)
            {

            }

        }

        private void gameRound()
        {
            int round = 1;
            Console.WriteLine($"ROUND: {round}");


            var PlayersByTurnOrder = Players.OrderBy(Player => Player.turnOrder).ToList();

            for(int i = 1; i < PlayersByTurnOrder.Count + 1; i++)
            {
                Console.WriteLine($"{PlayersByTurnOrder[i - 1]}'s turn! \n Roll DIE...");
                Console.ReadKey();

                int dieResult = 0; //WHERE DIE RESULT GO AKA     DIE.ROLL()

                


                



                

                switch(dieResult)
                {
                    case 1:
                        {
                            //METHOD TO ALLOW PIECE FROM FENCE TO BOARD

                            bool validoption = false;
                            do
                            {
                                Console.WriteLine("Do you want to: \n 1.Move piece from fence to board space 1 \n 2." +
                                                  "Move piece 1 space");

                                int pick = int.Parse(Console.ReadLine().ToString());

                                if (pick == 1)
                                {
                                    //MOVE PIECE FROM BOARD TO SPACE
                                    validoption = true;
                                }
                                else if (pick == 2)
                                {
                                    //MOVE PIECE ONE SPACE ON BOARD
                                    validoption = true;
                                }
                                else
                                {
                                    Console.WriteLine("ERROR: You have to pick a valid option");
                                }
                            } while (!validoption);

                            break;
                        }

                    case 6:
                        {
                            

                            bool validOption = false;

                            do
                            {
                                Console.WriteLine($"Do you want to: \n 1. Move two pieces from fence to board space 1 \n" +
                                $"2. Move one piece from fence to board space 6 \n 3. Move one piece 6 spaces");

                                int pick = int.Parse(Console.ReadLine());



                                if (pick == 1)
                                {
                                    //FLYTTA 2 PIECE FROM FENCE TO SPACE 1
                                    validOption = true;
                                }
                                else if (pick == 2)
                                {
                                    //FLYTTA PIECE FROM FENCE TO BOARD SPACE &
                                    validOption = true;
                                }
                                else if (pick == 3)
                                {
                                    //FLYTTA PIECE 6 SPACES
                                    validOption = true;
                                }
                                else
                                {
                                    Console.WriteLine("ERROR: INVALID INPUT");
                                }
                            } while (!validOption);



                            
                            break;
                        }

                    default:
                        {

                            if (dieResult > 6)
                            {
                                //ROLL DIE AGAIN AND ADD THE NUMBER
                                //CHOSE AND MOVE PIECE
                            }
                            else
                            {
                                Console.WriteLine($"Chose which piece you would like to move {dieResult} spaces");
                            }
                            //VÄLJ EN PIECE SOM FLYTTAS
                            break;
                        }
 
                }
                
                if(PlayersByTurnOrder[i-1].score == 4)
                {
                    Console.WriteLine($"Congratulations, {PlayersByTurnOrder[i-1]} is the winner!");
                }

            }

            round++;  
        }

    }
}
