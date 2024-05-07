using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var urls = new[] { "https://api.hh.ru/openapi/redoc#section/Obshaya-informaciya/Vybor-sajta", "https://discord.com/idasdad", "https://swagger.io/docs/specification/api-host-and-base-path/" };

            var currentTime = DateTime.Now;
            for (int i = 0; i < urls.Length; i++)
            {
                var response = client.GetAsync(urls[i]).Result;
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"URL{i + 1}: Error: {response.StatusCode}");
                }
                else
                {
                    var JSON = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"URL{i + 1}: {JSON}");
                }
            }
            var endTime = DateTime.Now;
            Console.WriteLine($"Total time: {endTime - currentTime}");
        }
     
    }
}