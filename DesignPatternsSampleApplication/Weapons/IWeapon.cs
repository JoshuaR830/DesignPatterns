using DesignPatternsSampleApplication.Enemies;

namespace DesignPatternsSampleApplication.Weapons
{
    /// <summary>
    /// Looking closely at loose coupling here
    /// As long as a weapon uses this interface it can be held and used by the player
    /// </summary>
    public interface IWeapon
    {
        // Implement a way that the weapon causes damage to the enemy
        void Use(IEnemy enemy);
    }
}