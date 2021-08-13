using DesignPatternsSampleApplication.Events;
using DesignPatternsSampleApplication.Strategies;

namespace DesignPatternsSampleApplication.Observers
{
    public class HealthChangedObserver
    {
        // This is a strategy that will be selected
        private IDamageIndicator _strategy;

        
        // Uses dependency inversion (though no DI container) - provided externally
        public HealthChangedObserver(IDamageIndicator strategy)
        {
            _strategy = strategy;
        }
        
        // Trigger a notification when health drops below 20HP
        // Register itself - no logic in the facade
        // Single responsibility principle
        public void WatchPlayerHealth(PrimaryPlayer player)
        {
            player.RegisterObserver(Handler);
        }

        private void Handler(object sender, HealthChangedEventArgs args)
        {
            int damage = args.Damage;
            int health = args.Health;

            _strategy.NotifyAboutDamage(health, damage);
        }
    }
}