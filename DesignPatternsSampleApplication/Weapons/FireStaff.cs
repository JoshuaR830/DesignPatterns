using DesignPatternsSampleApplication.Enemies;

namespace DesignPatternsSampleApplication.Weapons
{
    public class FireStaff : IWeapon
    {
        // If we want to keep a property private - need a backing field for it

        private readonly int _damage;
        private readonly int _fireDamage;
        
        public int Damage { get => _damage; }
        
        // No public getter for FireDamage - could have one if needed to display stats
        // Not needed to deal damage
        
        public FireStaff(int damage, int fireDamage)
        {
            _damage = damage;
            _fireDamage = fireDamage;
        }
        
        // Deal fire damage
        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.OvertimeDamage = _fireDamage;
        }
    }
}