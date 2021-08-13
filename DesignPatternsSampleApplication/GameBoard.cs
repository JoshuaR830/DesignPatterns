using System;
using System.Threading.Tasks;
using DesignPatternsSampleApplication.Adapters;
using DesignPatternsSampleApplication.Enemies;
using DesignPatternsSampleApplication.Facades;
using DesignPatternsSampleApplication.Weapons;
using NiceSpaceWeapons;

namespace DesignPatternsSampleApplication
{
    ///
    /// Should have a single responsibility - don't know how to create enemies
    /// Knows which stage player is in and what enemies the player has to face
    /// Enemies should be provided to the GameBoard by the enemy factory
    /// 
    public class GameBoard
    {
        private GameboardFacade _gameboardFascade;
        private PrimaryPlayer _player;

        
        private EnemyFactory _enemyFactory = new EnemyFactory(1);
        
        /// <summary>
        /// Get the instance of the primary player
        /// </summary>
        public GameBoard()
        {
            _player = PrimaryPlayer.Instance;
            _gameboardFascade = new GameboardFacade();
            
            // Could be any weapon implementing IWeapon
            _player.Weapon = new Sword(12, 8);
        }

        /// <summary>
        /// Spawn enemies depending on the level
        /// </summary>
        /// <param name="level"></param>
        public async Task PlayArea(int level)
        {
            if (level == -1)
            {
                Console.WriteLine("Play special level?");
                Console.ReadKey();
                PlaySpecialLevel();
            }
            else
            {
                await _gameboardFascade.Play(_player, level);
            }
        }

        private void PlaySpecialLevel()
        {
            // Take a new instance of the weapon and pass it to the adapter to convert it
            _player.Weapon = new WeaponAdapter(new Blaster(20, 15, 15));
        }
    }
}