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
                    //Serialization of Record to send to Web API
                    var rec = pro.Serializer("Nicole", "Cal Poly", 2020);

                    //Send request with serialized Record to web API, check status code
                    HttpResponseMessage response = await client.GetAsync("http://localhost:52513/api/values/" + rec);
                    response.EnsureSuccessStatusCode();

                    //Read the response and deserialize the Json string back into a Record
                    var readRecord = await response.Content.ReadAsStringAsync();
                    Record updated = pro.Deserializer(readRecord);

                    //Inspect the returned Record after deserializtion, make sure it has been updated
                    Console.WriteLine(updated.Name + " " + updated.University + " " + updated.GraduationY);
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
