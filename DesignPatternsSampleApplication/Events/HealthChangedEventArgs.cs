using System;

namespace DesignPatternsSampleApplication.Events
{
    public class HealthChangedEventArgs : EventArgs
    {
        public int Health { get; private set; }
        public int Damage { get; set; }

        // Initialise them
        // Event argument object created
        public HealthChangedEventArgs(int health, int damage)
        {
            Health = health;
            Damage = damage;
        }
    }
}