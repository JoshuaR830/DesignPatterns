using System;

namespace DesignPatternsSampleApplication.Enemies
{
    public class Werewolf : IEnemy
    {
        public int Health { get; set; }
        public int Level { get; }

        public Werewolf(int health, int level)
        {
            Health = health;
            Level = level;
        }
        
        public void Attack(PrimaryPlayer player)
        {
            Console.WriteLine($"Werewolf is attacking {player.Name}");
        }

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine($"Werewolf is defending {player.Name}");
        }
    }
}