namespace Common
{
    public class CardDecorator : Card
    {
        protected Card _card;
        
        // Decorator wraps a card object which must be provided
        // Only initialise the card that the decorator wraps in the constructor
        // Card needs to be immutable
        public CardDecorator(Card card, string name, int attack, int defence) : base(name, attack, defence)
        {
            _card = card;
        }

        // Combine the values
        public override string Name
        {
            get
            {
                return $"{_card.Name}, {_name}";
            }
        }

        public override int Attack
        {
            get
            {
                return _card.Attack + _attack;
            }
        }

        // Add card defence to the defence provided by the decorator
        public override int Defence
        {
            get
            {
                return _card.Defence + _defence;
            }
        }
    }
}