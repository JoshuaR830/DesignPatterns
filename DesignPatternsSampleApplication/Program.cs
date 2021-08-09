using System;

namespace DesignPatternsSampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimaryPlayer player = PrimaryPlayer.Instance;
            Console.WriteLine($"{player.Name} - lvl {player.Level}");
            Console.WriteLine("Hello World!");
        }
    }
}