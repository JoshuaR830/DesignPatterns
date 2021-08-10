using System;
using System.Collections.Generic;
using DesignPatternsSampleApplication.Enemies;
using DesignPatternsSampleApplication.Weapons;

namespace DesignPatternsSampleApplication
{
    ///
    /// Should have a single responsibility - don't know how to create enemies
    /// Knows which stage player is in and what enemies the player has to face
    /// Enemies should be provided to the GameBoard by the enemy factory
    /// 
    public class GameBoard
    {
        private PrimaryPlayer _player;

        private EnemyFactory _enemyFactory = new EnemyFactory(1);
        
        /// <summary>
        /// Get the instance of the primary player
        /// </summary>
        public GameBoard()
        {
            _player = PrimaryPlayer.Instance;
            
            // Could be any weapon implementing IWeapon
            _player.Weapon = new Sword(12, 8);
        }

        /// <summary>
        /// Spawn enemies depending on the level
        /// </summary>
        /// <param name="level"></param>
        public void PlayArea(int level)
        {
            if (level == 1)
            {
                PlayFirstLevel();
            }
        }

        private void PlayFirstLevel()
        {
            const int currentLevel = 1;
            
            // All items in this list implement the IEnemy interface - so we can use the factory pattern
            List<IEnemy> enemies = new List<IEnemy>();

            for (int i = 0; i < 10; i++)
            {
                // The factory will return the correct instance of the enemy for the level we are at
                // Don't make instances of the enemies here - use the factory
                enemies.Add(_enemyFactory.SpawnZombie(currentLevel));
            }
            
            for (int i = 0; i < 3; i++)
            {
                enemies.Add(_enemyFactory.SpawnWerewolf(currentLevel));
            }

            foreach (var enemy in enemies)
            {
                Console.WriteLine(enemy.GetType());
                
                // Simulate a battle until someone dies
                while (enemy.Health > 0 && _player.Health > 0)
                {   
                    // Loose coupling in action - player holds weapon of any type, only takes an enemy
                    // Any type of weapon can damage any type of enemy
                    // Depends on abstractions and not concrete implementations
                    _player.Weapon.Use(enemy);
                    enemy.Attack(_player);
                }

                if (enemy.Health <= 0)
                {
                    enemy.ReturnToObjectPool(_enemyFactory, enemy);
                }
            }
        }
    }
}