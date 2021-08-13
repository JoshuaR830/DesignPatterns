using System.Collections.Generic;
using System.Net.Http;
using DesignPatternsSampleApplication.Enemies;

namespace DesignPatternsSampleApplication.Facades
{
    public class GameboardFacade
    {
        private PrimaryPlayer _player;
        private int _areaLevel;
        private HttpClient _http;
        private EnemyFactory _factory;
        private List<IEnemy> _enemies;
        
        // Can have more than one public method in a facade
        // Delegate operation of each level to facade - doesn't need to be in the GameBoard class
        // No longer violate single responsibility principle of the GameBoard class
        public void Play(PrimaryPlayer player, int areaLevel)
        {
            ConfigurePlayerWeapon();
            AddPlayerCards();
            InitialiseEnemyFactory();
            LoadZombies();
            LoadWerewolves();
            LoadGiants();
        }
        
        private void ConfigurePlayerWeapon()
        {
            
        }

        private void AddPlayerCards()
        {
            
        }

        private void InitialiseEnemyFactory()
        {
            
        }

        private void LoadZombies()
        {
            
        }

        private void LoadWerewolves()
        {
            
        }

        private void LoadGiants()
        {
            
        }
    }
}