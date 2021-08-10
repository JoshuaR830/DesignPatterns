using System;

namespace DesignPatternsSampleApplication.Enemies
{
    public class Werewolf : IEnemy
    {
        // These are backing fields
        // Backing fields only discovered for properties in the model
        // Write to a field instead of a property
        // Encapsulation is being used to enhance semantics around access to the data by code
        // When using database - should not have the restrictions - hence still use properties
        // Allows you to change the implementation details of the class without changing it's interface
        
        private int _health;
        private int _level;
        
        public int Health { get => _health; set => _health = value; }
        public int Level { get => _level; }
        
        
        public int OvertimeDamage { get; set; }
        public int Armor { get; set; }
        public bool IsParalyzed { get; set; }
        public int RoundsParalyzedFor { get; set; }

        public Werewolf(int health, int level)
        {
            _health = health;
            _level = level;
        }
        
        public void Attack(PrimaryPlayer player)
        {
            Console.WriteLine($"Werewolf is attacking {player.Name}");
        }

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine($"Werewolf is defending {player.Name}");
        }

        public void ReturnToObjectPool(EnemyFactory factory)
        {
            factory.ReclaimWarewolf(this);
        }
    }
}