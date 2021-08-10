using System;

namespace DesignPatternsSampleApplication.Enemies
{
    
    /// <summary>
    /// Implement the enemy interface
    /// Can have any number of different enemy types now
    /// </summary>
    public class Zombie : IEnemy
    {
        public int Health { get; set; }

        public int Level { get; }

        public Zombie(int health, int level)
        {
            Health = health;
            Level = level;
        }

        public void Attack(PrimaryPlayer player)
        {
            Console.WriteLine($"Zombie attacking {player.Name}");
        }

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine($"Zombie defending {player.Name}");
        }
    }
}