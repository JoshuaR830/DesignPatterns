using DesignPatternsSampleApplication.Enemies;

namespace DesignPatternsSampleApplication.Weapons
{
    public class IceStaff : IWeapon
    {
        // If we want to keep a property private - need a backing field for it
        private readonly int _damage;
        private readonly int _paralyzedFor;
        public int Damage { get => _damage; }

        public IceStaff(int damage, int roundsParalyzedFor)
        {
            _damage = damage;
            _paralyzedFor = roundsParalyzedFor;
        }
        
        // Paralyze enemies
        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.IsParalyzed = true;
            enemy.RoundsParalyzedFor = _paralyzedFor;
        }
    }
}