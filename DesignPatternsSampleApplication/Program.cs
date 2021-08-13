using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatternsSampleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TestApiConnection().Wait();
                GameBoard board = new GameBoard();
                board.PlayArea(1).Wait();
            }
            catch (Exception e)
            {
                // If all 20 fail
                Console.WriteLine("Failed to initialize game");
                Console.ReadKey();
            }
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
    }
}