using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine
{
    class Piece
    {
        public int relativePosition { get; set; } 
        public int spacesFromGoal { get; set; }
        public string Color { get; set; }
        public bool OnBoard { get; set; }
        public bool inGoal { get; set; }


        public Piece(string Color, int Order)
        {
            this.Color = Color;
            this.spacesFromGoal = 57;
            this.OnBoard = false;
            this.inGoal = false;
            switch(Order)
            {
                case 1:
                    {
                        relativePosition = 1;
                        break;
                    }
                case 2:
                    {
                        relativePosition = 14;
                            break;
                    }
                case 3:
                    {
                        relativePosition = 27;
                        break;
                    }
                    
                case 4:
                    {
                        relativePosition = 40;
                        break;
                    }

            }
        }


        public void movePiece(int spaces)
        {
            if(relativePosition + spaces > 52)
            {
               relativePosition += spaces - 52;
            }
            else
            {
                relativePosition += spaces;
            }

            spacesFromGoal -= spaces;
 
            if(spacesFromGoal <= 0)
            {
                inGoal = true;
            }
            

        }

        

    }
}
