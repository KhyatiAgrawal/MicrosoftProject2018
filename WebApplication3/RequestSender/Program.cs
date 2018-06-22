using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RequestSender
{
    class Program
    {
        static void Main()
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            // Create a New HttpClient object.
            HttpClient client = new HttpClient();
                // Call asynchronous network methods in a try/catch block to handle exceptions
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://localhost:52513/api/values/foo");
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();

                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    Console.WriteLine(responseBody);
                    Console.ReadKey();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            


        }
    }
}
