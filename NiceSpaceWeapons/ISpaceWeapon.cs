namespace SpaceWeapons
{
    public interface ISpaceWeapon
    {
        int ImpactDamage { get; set; }
        int LaserDamage { get; set; }
        int MissChance { get; set; }
        
        int Shoot();
    }
}