using System;
using System.Collections.Generic;

namespace Ludo.Engine
{
    public class Piece
    {
        public int position;

        public int id;

        public Piece (int id)
        {
            this.id = id;
        }

        public bool IsInYard()
        {
            return position == 0;
        }

        public bool IsInGoal()
        {
            return position > 62;
        }

        public int StepsUntilGoal()
        {
            return 63 - position;
        }

        public void Move(int steps)
        {
            position += steps;
        }
    }

    public class Player
    {
        Piece[] pieces = new Piece[] { new Piece (1), new Piece(2), new Piece(3), new Piece(4) };

        public string color = "";

        public void MovePieceOntoBoard(int choice)
        {
            pieces[choice].position = 1;
        }

        public void PlayerMovePiece(int id, int diceroll)
        {
            pieces[id].Move(diceroll);
        }

        public void ShowInfo()
        {
            foreach (Piece P in pieces)
            {
                if (P.IsInYard())
                {
                    Console.WriteLine("The Player's " + color +
                        " piece number " + P.id + " is in position: 0");
                }
                else
                {
                    Console.WriteLine("The Player's " + color +
                      " piece number " + P.id + " is in position: " + P.position + 
                      " and has this many steps until the goal: " + P.StepsUntilGoal());
                }
            } 
        }

        public bool CanPutPieceInPlay(int diceroll)
        {
            if (diceroll != 6)
            {
                return false;
            }
            else
            {
                foreach (Piece P in pieces)
                {
                    if (P.IsInYard())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveAnyPieces(int diceroll)
        {
            foreach (Piece p in pieces)
            {
                if (!p.IsInYard() && !p.IsInGoal() && !(p.position > 56 && p.StepsUntilGoal() != diceroll))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Won ()
        {
            foreach (Piece p in pieces)
            {
                if (!p.IsInGoal())
                {
                    return false;
                }
            }
            return true;
        }

        public bool CanMovePiece(int piecenumber, int diceroll)
        {
            if (pieces[piecenumber].IsInYard() || pieces[piecenumber].IsInGoal())
            {
                Console.WriteLine("Can not move this piece. Please try again.");
                return false;
            }
            if (pieces[piecenumber].position > 56 && pieces[piecenumber].StepsUntilGoal() != diceroll)
            {
                Console.WriteLine("You can not move a piece due to the rules restrictions. You skip the move until you throw a certain dice number");
                return false;
            }

            return true;
        }
    }

    public class Dice
    {
        Random rnd = new Random();

        public int Roll()
        {
            return rnd.Next(1, 7);
        }
    }

    public class Board
    {
        List<Player> players = new List<Player>();
                
        int turn;

        public void AddPlayer(Player P)
        {
            players.Add(P);
        }

        public Player GetCurrentPlayer()
        {
            return players[turn];
        }

        public void NextTurn()
        {
            turn = turn + 1;
            if (turn >= players.Count)
            {
                turn = 0;
            }
        }
    }
}
