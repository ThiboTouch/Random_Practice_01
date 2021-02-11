using System;

namespace GameOfLife
{
    internal class Program
    {

        // Constants for the game rules.
        private const int Heigth = 10;
        private const int Width = 30;
        private const uint MaxRuns = 100;

        private static void Main(string[] args)
        {
            int runs = 0;
            LifeSimulation sim = new LifeSimulation(Heigth, Width);

            while (runs++ < MaxRuns)
            {
                sim.DrawAndGrow();

                // Give the user a chance to view the game in a more reasonable speed.
                System.Threading.Thread.Sleep(100);
            }

            Console.SetCursorPosition(0, 11);
        }
    }
}