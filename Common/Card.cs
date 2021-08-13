using System.Text.Json.Serialization;

namespace Common
{
    public class Card
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("attack")]
        public int Attack { get; set; }
        
        [JsonPropertyName("defence")]
        public int Defence { get; set; }
    }
}