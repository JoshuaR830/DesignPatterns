using System;

namespace SpaceWeapons
{
    public class Blaster : ISpaceWeapon
    {
        public int ImpactDamage { get; set; }
        public int LaserDamage { get; set; }
        public int MissChance { get; set; }

        public Blaster(int impact, int laser, int missChance)
        {
            ImpactDamage = impact;
            LaserDamage = laser;
            MissChance = missChance;
        }
        
        public int Shoot()
        {
            var rand = new Random();
            var selectedNum = rand.Next(0, 100);

            if (selectedNum < MissChance)
            {
                return 0;
            }

            return ImpactDamage + LaserDamage;
        }
    }
}