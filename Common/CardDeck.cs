using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    // Works like delegate for collection
    // Need more than just a list or an array - need to control the operations that can be done
    // Implementing the ICardComponent means the list can be iterated through, even if they are not the same
    public class CardDeck : ICardComponent
    {
        // Generic list has multiple things - but we want to limit that for the Card Deck
        // Only expose the parts of the API we want
        private List<ICardComponent> _components = new List<ICardComponent>();


        public void Add(ICardComponent component)
        {
            _components.Add(component);
        }

        public ICardComponent Get(int index)
        {
            return _components[index];
        }

        public bool Remove(ICardComponent component)
        {
            return _components.Remove(component);
        }

        public string Display()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var component in _components)
            {
                // Strings are immutable in C# - best to use a string builder
                builder.Append(component.Display() + "\r\n");
            }

            return builder.ToString();
        }

        // Issue - we can't add other deck to this card deck - only dealing with cards
        // It can't hold different decks in the same list - we need to have unified access to all cards - recursive way
        // Shouldn't care if it is a card or a deck - unified access - all cards if it is a deck, the individual card if not
        [Obsolete("This would not use the composite pattern and would be clunky, do something else instead")]
        public void AddDeck(CardDeck deck)
        {
            // This is not elegant - that's why we need the composite pattern
        }
    }
}