using System.Collections.Generic;
using Common;

namespace Api.Services
{
    
    // Need to register this in the .NET Core DI container 
    public class CardService : ICardService
    {
        public IEnumerable<Card> FetchCards()
        {
            return new List<Card>()
            {
                new Card() {Attack = 90, Defence = 80, Name = "Ultimate Shadow Wraith"},
                new Card() {Attack = 64, Defence = 91, Name = "Puppet of Doom"},
                new Card() {Attack = 77, Defence = 61, Name = "Lost Soul"},
                new Card() {Attack = 55, Defence = 57, Name = "Plague Druid"},
                new Card() {Attack = 90, Defence = 95, Name = "Rage Dragon"}
            };
        }
    }
}