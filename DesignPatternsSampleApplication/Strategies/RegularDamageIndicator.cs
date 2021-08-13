using System;

namespace DesignPatternsSampleApplication.Strategies
{
    public class RegularDamageIndicator : IDamageIndicator
    {
        public void NotifyAboutDamage(int health, int damage)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Player took {damage} and still has {health} HP");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}