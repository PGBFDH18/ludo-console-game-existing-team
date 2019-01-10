using System;
using System.Collections.Generic;


namespace GameEngine
{
    public class Player
    {
        public string name { get; set; }
        public string color { get; set; }
        public int turnOrder { get; set; }

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
            Console.WriteLine($"Please chose the piece you would like to move {spaces} spaces");

            for(int i = 1; i < Pieces.Count + 1; i++)
            {
                if(Pieces[i].OnBoard && !Pieces[i].inGoal)
                Console.WriteLine($"{i}. {Pieces[i]}");
            }

            int Choice = int.Parse(Console.ReadLine().ToString());

           Pieces[Choice].movePiece(spaces);

        }

       

        
    }
}
