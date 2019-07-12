using System;

namespace Ex02_Othelo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleUI game = new ConsoleUI();
            game.BeginGame();
            Console.ReadKey();
        }
    }
}
