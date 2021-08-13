﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Common;
using DesignPatternsSampleApplication.Adapters;
using DesignPatternsSampleApplication.Enemies;
using DesignPatternsSampleApplication.Weapons;
using SpaceWeapons;

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
        public async Task PlayArea(int level)
        {
            if (level == 1)
            {
                _player.Cards = (await FetchCards()).ToArray();
                Console.WriteLine("Ready to start level 1");
                Console.ReadKey();
                PlayFirstLevel();
            } else if (level == -1)
            {
                Console.WriteLine("Play special level?");
                Console.ReadKey();
                PlaySpecialLevel();
            }
        }

        private void PlaySpecialLevel()
        {
            // Take a new instance of the weapon and pass it to the adapter to convert it
            _player.Weapon = new WeaponAdapter(new Blaster(20, 15, 15));
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
                    enemy.ReturnToObjectPool(_enemyFactory);
                }
            }
        }
        
        private async Task<IEnumerable<Card>> FetchCards()
        {
            using (var http = new HttpClient())
            {
                var cardJson = await http.GetStringAsync("http://localhost:5000/api/cards");

                return JsonSerializer.Deserialize<IEnumerable<Card>>(cardJson);
            };
        }
    }
}