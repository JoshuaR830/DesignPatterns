namespace DesignPatternsSampleApplication.Strategies
{
    // Implemented by every class that is a damage indicator
    // The strategy can be chosen based on context - should always be from the same family of classes
    // The class must implement the IDamageIndicator
    public interface IDamageIndicator
    {
        void NotifyAboutDamage(int health, int damage);
    }
}