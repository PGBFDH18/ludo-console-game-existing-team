using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine
{
    public class Player
    {
        public string name { get; set; }
        public string color { get; set; }
        public int turnOrder { get; set; }
        public bool turnDone { get; set; }
        public int score { get; set; }
        Dictionary<int, Piece> Pieces;

        

        public Player(string name, string color, int turnOrder)
        {
            
            this.name = name;
            this.color = color;
            this.turnOrder = turnOrder;
            Pieces = new Dictionary<int, Piece>()
            {
                {1,new Piece(color, turnOrder)},
                {2,new Piece(color, turnOrder)},
                {3,new Piece(color, turnOrder)},
                {4,new Piece(color, turnOrder)}
            };
        }

        public void ChosePieceMove(int spaces)
        {

            bool hasMovable = false;


            foreach(Piece p in Pieces.Values)
            {
                if(p.OnBoard == true)
                {
                    hasMovable = true;
                }
            }


            if (hasMovable)
            {

                Console.WriteLine($"Please chose the piece you would like to move {spaces} spaces");

                for (int i = 1; i < Pieces.Count + 1; i++)
                {
                    if (Pieces[i].OnBoard && !Pieces[i].inGoal)
                        Console.WriteLine($"{i}. Spaces from goal: {Pieces[i].spacesFromGoal}, Position on map: {Pieces[i].relativePosition}");
                }

                int Choice = int.Parse(Console.ReadLine().ToString());

                Pieces[Choice].movePiece(spaces);

                if (Pieces[Choice].inGoal == true)
                {
                    score++;
                }
            }
            else
            {
                Console.WriteLine($"No pieces currently on the board...");
            }
        }

        public void ChosePieceFromFence(int spaces)
        {
            

           
                for (int i = 1; i < Pieces.Count+1; i++)
                {
                    if (!Pieces[i].OnBoard)
                    {
                        Console.WriteLine($"{i}. Spaces from Goal: {Pieces[i].spacesFromGoal}, Position on map: {Pieces[i].relativePosition}");
                    }
                    
                }

            int choice = int.Parse(Console.ReadLine().ToString());
            Pieces[choice].OnBoard = true;
            Pieces[choice].movePiece(spaces);


        }

        

       

        
    }
}
