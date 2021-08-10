using System;

namespace DesignPatternsSampleApplication.Enemies
{
    public class Giant : IEnemy
    {
        public int Health { get; set; }
        public int Level { get; }

        public Giant(int health, int level)
        {
            Health = health;
            Level = level;
        }
        
        public void Attack(PrimaryPlayer player)
        {
            Console.WriteLine($"Giant is attacking {player.Name}");
        }

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine($"Giant is defending {player.Name}");
        }
    }
}