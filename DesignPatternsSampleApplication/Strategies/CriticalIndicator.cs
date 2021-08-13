using System;

namespace DesignPatternsSampleApplication.Strategies
{
    public class CriticalIndicator : IDamageIndicator
    {
        public void NotifyAboutDamage(int health, int damage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"CRITICAL HEALTH you took {damage} damage points and have {(health < 0 ? 0 : health)} remaining");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}