using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Bond;
using Bond.Protocols;
using Examples;

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
                    var rec = pro.Serializer("Nicole", "Cal Poly", 2020);
                    
                    HttpResponseMessage response = await client.GetAsync("http://localhost:52513/api/values/" + rec);
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();

                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                var reader = new SimpleJsonReader(new StringReader(responseBody));
                var readRecord = Deserialize<Record>.From(reader);
                
                Console.WriteLine(readRecord.Name + " " + readRecord.University + " " + readRecord.GraduationY);
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
