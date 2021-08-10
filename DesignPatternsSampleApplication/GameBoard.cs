using System;
using System.Collections.Generic;
using DesignPatternsSampleApplication.Enemies;

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
        
        /// <summary>
        /// Get the instance of the primary player
        /// </summary>
        public GameBoard()
        {
            _player = PrimaryPlayer.Instance;
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
                enemies.Add(EnemyFactory.SpawnZombie(currentLevel));
            }
            
            for (int i = 0; i < 3; i++)
            {
                enemies.Add(EnemyFactory.SpawnWerewolf(currentLevel));
            }

            foreach (var enemy in enemies)
            {
                Console.WriteLine(enemy.GetType());
            }
        }
    }
}