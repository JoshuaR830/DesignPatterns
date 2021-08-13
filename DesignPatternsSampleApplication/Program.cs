using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common;
using DesignPatternsSampleApplication.Battlefields;
using DesignPatternsSampleApplication.Facades;

namespace DesignPatternsSampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // PrimaryPlayer player = PrimaryPlayer.Instance;
            //
            // try
            // {
            //     TestApiConnection().Wait();
            //     GameboardFacade board = new GameboardFacade();
            //     board.Play(player, 1).Wait();
            // }
            // catch (Exception e)
            // {
            //     // If all 20 fail
            //     Console.WriteLine("Failed to initialize game");
            //     Console.ReadKey();
            // }

            TestBattlefields();
        }

        private static void TestBattlefields()
        {
            // Easy to change the values based on the template
            BattlefieldTemplate battlefield = new SnowyBattlefield();
            Console.WriteLine(battlefield.Describe());
        }

        private static async Task TestApiConnection()
        {
            // Attempt to connect to the api multiple times
            int maxAttempts = 20;
            
            // Interval ms
            int attemptInterval = 2000;

            using (var http = new HttpClient())
            {
                for (int i = 0; i < maxAttempts; i ++ )
                {
                    try
                    {
                        // Check if the api is up and running on a default endpoint
                        var response = await http.GetAsync("http://localhost:5000/api/cards");

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return;
                        }
                    }
                    catch (Exception e)
                    {

                    }
                    finally
                    {
                        // If response is not OK and an exception is thrown then this will be reached
                        Console.WriteLine("Lost connection to server.");
                        Thread.Sleep(attemptInterval);
                    }
                }
                
                throw new Exception("Failed to connect to server");
            }
        }

        private static void TestDecorators()
        {
            Card soldier = new Card("Soldier", 25, 20);
            
            // Always assign value to the soldier object - the decorators are also cards
            // Caller doesn't know it has been wrapped - just appears as the soldier class
            // Can't see that it is a chain of decorators
            soldier = new AttackDecorator(soldier, "Sword", 15);
            soldier = new AttackDecorator(soldier, "Amulet", 5);
            soldier = new DefenceDecorator(soldier, "Helmet", 10);
            soldier = new DefenceDecorator(soldier, "Heavy Armour", 45);

            Console.WriteLine($"Final stats: {soldier.Attack} / {soldier.Defence}");
        }

        private static void TestComposite()
        {
            CardDeck deck = new CardDeck();
            CardDeck attackDeck = new CardDeck();
            CardDeck defenceDeck = new CardDeck();
            
            attackDeck.Add(new Card("Basic Infantry Unit", 12, 15));
            attackDeck.Add(new Card("Advanced Infantry Unit", 24, 18));
            attackDeck.Add(new Card("Cavalry Unit", 30, 22));
            
            defenceDeck.Add(new Card("Wooden Shield", 0, 4));
            defenceDeck.Add(new Card("Iron Shield", 0, 9));
            defenceDeck.Add(new Card("Shining Royal Armour", 0, 40));
            
            deck.Add(attackDeck);
            deck.Add(new Card("Small Beast", 10, 3));
            deck.Add(new Card("High Elf Rogue", 14, 9));
            deck.Add(defenceDeck);

            Console.WriteLine(deck.Display());
        }
    }
}