using System;
using GameEngine;

namespace LudoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Ludo!");
            Console.WriteLine("Number of players:");
            int numberOfPlayers = int.Parse(Console.ReadLine());
            var game = new GameEngine.LudoGame();
            game.StartGame(numberOfPlayers);
        }
    }
}
