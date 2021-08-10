using DesignPatternsSampleApplication.Enemies;

namespace DesignPatternsSampleApplication.Weapons
{
    public class Sword : IWeapon
    {
        // If we want to keep a property private - need a backing field for it

        private readonly int _damage;
        public int Damage { get => _damage; }

        private readonly int _armourDamage;
        
        public int ArmourDamage { get => _armourDamage; }
        
        public Sword(int damage, int armourDamage)
        {
            _damage = damage;
            _armourDamage = armourDamage;
        }
        
        // Reduce armour
        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.Armor -= ArmourDamage;
        }
    }
}