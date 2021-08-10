namespace DesignPatternsSampleApplication.Enemies
{
    /// <summary>
    /// Loose coupling is made possible through use of the IEnemy interface
    /// </summary>
    public interface IEnemy
    {
        int Health { get; set; }
        int Level { get; }
        int OvertimeDamage { get; set; }
        int Armor { get; set; }
        bool IsParalyzed { get; set; }
        int RoundsParalyzedFor { get; set; }
        
        void Attack(PrimaryPlayer player);
        void Defend(PrimaryPlayer player);
        void ReturnToObjectPool(EnemyFactory factory);
    }
}