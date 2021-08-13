using DesignPatternsSampleApplication.Enemies;
using DesignPatternsSampleApplication.Weapons;
using NiceSpaceWeapons;

namespace DesignPatternsSampleApplication.Adapters
{
    // Must implement IWeapon interface the target interface
    public class WeaponAdapter : IWeapon
    {
        private ISpaceWeapon _spaceWeapon;

        public WeaponAdapter(ISpaceWeapon spaceWeapon)
        {
            _spaceWeapon = spaceWeapon;
        }

        public int Damage => _spaceWeapon.ImpactDamage + _spaceWeapon.LaserDamage;
        
        
        // Adapt the non-matching interface to meet the needs of our interface
        public void Use(IEnemy enemy)
        {
            // Shoot is different - doesn't take an enemy class
            // Shoot returns a value but enemy doesn't - we just need to achieve the same outcome here
            enemy.Health -= _spaceWeapon.Shoot();
        }
    }
}