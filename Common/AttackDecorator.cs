namespace Common
{
    // Only increase the attack stats
    // No need to provide defence - it will always be 0
    public class AttackDecorator : CardDecorator
    {
        protected Card _card;
        
        // Because this is just attack, we can make defense 0
        // Everything else handled by overridden getters
        public AttackDecorator(Card card, string name, int attack) : base(card, name, attack, 0)
        {
        }
    }
}