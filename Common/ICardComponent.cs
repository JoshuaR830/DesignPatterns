namespace Common
{
    // Cards and decks will both implement a common interface
    // Store a list of ICardComponents in the CardDeck
    
    // Methods that need to be implemented by the CardDeck
    // CardDeck needs to be responsible for adding new CardComponents to a list
    public interface ICardComponent
    {
        void Add(ICardComponent component);
        ICardComponent Get(int index);
        bool Remove(ICardComponent component);
        string Display();
    }
}