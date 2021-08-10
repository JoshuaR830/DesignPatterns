namespace DesignPatternsSampleApplication.Enemies
{
    /// <summary>
    /// Factories don't need to be static - but sometimes they can be
    /// Sometimes factories need to hold state
    /// So in essence - the point of this is to have responsibility for the creation of many types of thing that share an interface
    /// Another class can then use the created classes that the factory creates without knowledge of the implementation - allowing for single responsibility
    /// </summary>
    public static class EnemyFactory
    {
        /// <summary>
        /// Need to know how to spawn each type of enemy
        /// All implement the same interface
        /// Can now create enemies of different types without needing different "containers"
        /// </summary>

        public static Werewolf SpawnWerewolf(int areaLevel)
        {
            // Create enemies according to area level - later game - better player
            if (areaLevel < 5)
                return new Werewolf(100, 12);

            return new Werewolf(100, 20);
        }

        public static Giant SpawnGiant(int areaLevel)
        {
            if (areaLevel < 8)
                return new Giant(100, 14);

            return new Giant(100, 32);
        }

        public static Zombie SpawnZombie(int areaLevel)
        {
            if (areaLevel < 3)
            {
                return new Zombie(66, 2, 15);
            }
            else if (areaLevel < 10)
            {
                return new Zombie(66, 5, 15);
            }
            else
            {
                return new Zombie(100, 8, 15);
            }
        }
    }
}