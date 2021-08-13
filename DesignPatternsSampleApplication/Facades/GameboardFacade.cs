using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DesignPatternsSampleApplication.Enemies;
using DesignPatternsSampleApplication.Proxies;
using DesignPatternsSampleApplication.Weapons;

namespace DesignPatternsSampleApplication.Facades
{
    public class GameboardFacade
    {
        private PrimaryPlayer _player;
        private int _areaLevel;
        private HttpClient _http;
        private EnemyFactory _factory;
        private List<IEnemy> _enemies;
        private CardsProxy _cardsProxy;

        public GameboardFacade()
        {
            _cardsProxy = new CardsProxy();
        }
        
        // Can have more than one public method in a facade
        // Delegate operation of each level to facade - doesn't need to be in the GameBoard class
        // No longer violate single responsibility principle of the GameBoard class
        public async Task Play(PrimaryPlayer player, int areaLevel)
        {
            _player = player;
            _areaLevel = areaLevel;
            _enemies = new List<IEnemy>();

            ConfigurePlayerWeapon();
            await AddPlayerCards();
            InitialiseEnemyFactory(areaLevel);
            LoadZombies(areaLevel);
            LoadWerewolves(areaLevel);
            LoadGiants(areaLevel);
            
            foreach (var enemy in _enemies)
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
                    enemy.ReturnToObjectPool(_factory);
                }
            }
        }
        
        private void ConfigurePlayerWeapon()
        {
            string input;
            bool askPlayer = true;
            
            while (askPlayer)
            {
                // Avoid this in the GameBoard class - not a responsibility of this
                // Functionality related closely to implementation - the console - what if there was another type of interface
                Console.WriteLine("Pick a weapon: ");
                Console.WriteLine("1. Sword");
                Console.WriteLine("2. Fire Staff");
                Console.WriteLine("3. Ice Staff");
                input = Console.ReadLine();

                if (Int32.TryParse(input, out int choice))
                {
                    Console.WriteLine(choice);
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("One");
                            _player.Weapon = new Sword(15, 7);
                            askPlayer = false;
                            break;
                        case 2:
                            _player.Weapon = new FireStaff(12, 14);
                            askPlayer = false;
                            break;
                        case 3:
                            _player.Weapon = new IceStaff(5, 1);
                            askPlayer = false;
                            break;
                        default:
                            Console.WriteLine("Incorrect input");
                            continue;
                    };
                }

                if (askPlayer)
                {
                    Console.WriteLine("Incorrect input");
                }
            }
        }

        private async Task AddPlayerCards()
        {
            // Fetching the cards is not the responsibility of the GameBoardFacade - it's responsibility it to prepare the gameboard
            // So we use proxy
            _player.Cards = (await _cardsProxy.GetCards()).ToArray();
        }

        private void InitialiseEnemyFactory(int areaLevel)
        {
            _factory = new EnemyFactory(areaLevel);
        }

        private void LoadZombies(int areaLevel)
        {
            int count = (areaLevel < 3 ? 10 : (areaLevel < 10) ? 20 : 30);
            
            for (int i = 0; i < count; i++)
            {
                // The factory will return the correct instance of the enemy for the level we are at
                // Don't make instances of the enemies here - use the factory
                _enemies.Add(_factory.SpawnZombie(areaLevel));
            }
        }

        private void LoadWerewolves(int areaLevel)
        {
            int count = (areaLevel < 5 ? 3 : 10);
            
            for (int i = 0; i < count; i++)
            {
                // The factory will return the correct instance of the enemy for the level we are at
                // Don't make instances of the enemies here - use the factory
                _enemies.Add(_factory.SpawnWerewolf(areaLevel));
            }
        }

        private void LoadGiants(int areaLevel)
        {
            int count = (areaLevel < 8 ? 1 : 3);
            
            for (int i = 0; i < count; i++)
            {
                // The factory will return the correct instance of the enemy for the level we are at
                // Don't make instances of the enemies here - use the factory
                _enemies.Add(_factory.SpawnGiant(areaLevel));
            }
        }
    }
}