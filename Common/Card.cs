using System.Text.Json.Serialization;

namespace Common
{
    // A Card does not need to implement everything that the ICardComponent
    public class Card : ICardComponent
    {
        protected string _name;
        protected int _attack;
        protected int _defence;

        public Card(string name, int attack, int defence)
        {
            _name = name;
            _attack = attack;
            _defence = defence;
        }

        
        // Virtual properties allow them to be overwritten by decorators
        [JsonPropertyName("name")]
        public virtual string Name
        {
            get
            {
                return _name;
            }
        }
        
        [JsonPropertyName("attack")]
        public virtual int Attack
        {
            get
            {
                return _attack;
            }
        }
        
        [JsonPropertyName("defence")]
        public virtual int Defence
        {
            get
            {
                return _defence;
            }
        }

        public void Add(ICardComponent component)
        {
            throw new System.InvalidOperationException();
        }

        public ICardComponent Get(int index)
        {
            throw new System.InvalidOperationException();
        }

        public bool Remove(ICardComponent component)
        {
            throw new System.InvalidOperationException();
        }

        public string Display()
        {
            return $"{_name}: {_attack} / {_defence}";
        }
    }
}