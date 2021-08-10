using System;
using System.Collections.Generic;

namespace DesignPatternsSampleApplication.Enemies
{
    /// <summary>
    /// Factories don't need to be static - but sometimes they can be
    /// Sometimes factories need to hold state
    /// So in essence - the point of this is to have responsibility for the creation of many types of thing that share an interface
    /// Another class can then use the created classes that the factory creates without knowledge of the implementation - allowing for single responsibility
    /// </summary>
    public class EnemyFactory
    {
        private int _areaLevel;
        
        // Store the objects
        // Stacks - generic collections
        private Stack<Zombie> _zombiesPool = new Stack<Zombie>();
        private Stack<Werewolf> _werewolvesPool = new Stack<Werewolf>();
        private Stack<Giant> _giantsPool = new Stack<Giant>();
        
        public int AreaLevel
        {
            get => _areaLevel; 
        }

        // Number of enemies depends on level reached in the game
        public EnemyFactory(int areaLevel)
        {
            _areaLevel = areaLevel;
            
            // Need to pre-load before we actually need them for the object pool to work
            PreLoadZombies();
            PreLoadGiants();
            PreLoadWerewolves();
        }

        private void PreLoadZombies()
        {
            int count;
            
            // Cope with different stats in different circumstances
            // Populate pool with correct instance based on level
            if (_areaLevel < 3)
            {
                count = 15;
            }
            else if (_areaLevel < 10)
            {
                count = 50;
            }
            else
            {
                count = 200;
            }

            (int health, int level, int armour) = GetZombieStatus(_areaLevel);

            // Avoid repetition - initialise the stats then loop
            for (int i = 0; i < count; i++)
            {
                _zombiesPool.Push(new Zombie(health, level, armour));
            }
        }
        
        // Need to be able to get the stats for a zombie
        public (int health, int level, int armour) GetZombieStatus(int areaLevel)
        {
            return _areaLevel switch
            {
                // Cope with different stats in different circumstances
                // Populate pool with correct instance based on level
                < 3 => (66, 2, 15),
                < 10 => (66, 5, 15),
                _ => (100, 8, 15)
            };
        }

        // Avoid using up a zombie - the whole point is to return it to the pool
        public void ReclaimZombie(Zombie zombie)
        {
            (int health, int level, int armour) = GetZombieStatus(_areaLevel);
            zombie.Health = health;
            zombie.Armor = armour;
            
            // Zombie level is readonly and can't be changed - neither can it be changed anywhere else - so no need to reset it
            
            // Reclaimed by the object pool
            _zombiesPool.Push(zombie);
            Console.WriteLine("Reclaimed Zombie");
        }
        
        private void PreLoadGiants()
        {
            int count;
            
            // Cope with different stats in different circumstances
            // Populate pool with correct instance based on level
            if (_areaLevel < 8)
            {
                count = 15;
            }
            else
            {
                count = 30;
            }

            (int health, int level) = GetGiantStatus(_areaLevel);

            // Avoid repetition - initialise the stats then loop
            for (int i = 0; i < count; i++)
            {
                _giantsPool.Push(new Giant(health, level));
            }
        }
        
        private (int health, int level) GetGiantStatus(int areaLevel)
        {
            return areaLevel switch
            {
                < 8 => (100, 14),
                _ => (100, 32)
            };
        }

        public void ReclaimGiant(Giant giant)
        {
            (int health, int level) = GetGiantStatus(_areaLevel);
            giant.Health = health;
            
            _giantsPool.Push(giant);
            Console.WriteLine("Reclaimed Giant");
        }

        private void PreLoadWerewolves()
        {
            int count;
            
            // Cope with different stats in different circumstances
            // Populate pool with correct instance based on level
            if (_areaLevel < 5)
            {
                count = 15;
            }
            else
            {
                count = 30;
            }

            (int health, int level) = GetWerewolfStatus(_areaLevel);

            // Avoid repetition - initialise the stats then loop
            for (int i = 0; i < count; i++)
            {
                _werewolvesPool.Push(new Werewolf(health, level));
            }
            
        }
        
        public void ReclaimWarewolf(Werewolf werewolf)
        {
            (int health, int level) = GetWerewolfStatus(_areaLevel);
            werewolf.Health = health;
            
            _werewolvesPool.Push(werewolf);
            Console.WriteLine("Reclaimed Werewolf");
        }

        private (int health, int level) GetWerewolfStatus(int areaLevel)
        {
            return areaLevel switch
            {
                < 5 => (100, 12),
                _ => (100, 20)
            };
        }
        
        /// <summary>
        /// Need to know how to spawn each type of enemy
        /// All implement the same interface
        /// Can now create enemies of different types without needing different "containers"
        /// </summary>

        public Werewolf SpawnWerewolf(int areaLevel)
        {
            if (_werewolvesPool.Count > 0)
            {
                Console.WriteLine("Popped Werewolf");
                return _werewolvesPool.Pop();
            }

            throw new Exception("No werewolves left in pool");
        }

        public Giant SpawnGiant(int areaLevel)
        {
            if (_giantsPool.Count > 0)
            {
                Console.WriteLine("Popped Giant");
                return _giantsPool.Pop();
            }

            throw new Exception("No giants left in pool");
        }

        public Zombie SpawnZombie(int areaLevel)
        {
            if (_zombiesPool.Count > 0)
            {
                Console.WriteLine("Popped Zombie");
                return _zombiesPool.Pop();
            }

            throw new Exception("Zombie pool depleted");
        }
    }
}