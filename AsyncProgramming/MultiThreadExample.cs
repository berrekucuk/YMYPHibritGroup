using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    internal class MultiThreadExample
    {
        //Eğer bir operasyonu aynı anda başlatmak istiyorak ve CPU yoracak bir işlemse multithread yazılır.

        public Task Example1()
        {
            var httpClient = new HttpClient();

            Task.Run(async () =>
            {
                var response = await httpClient.GetAsync("https://www.google.com");

                var responseAsText = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"1.Thread Gelen Data Length:{responseAsText.Length}");
            });

            Task.Run(async () =>
            {
                var response = await httpClient.GetAsync("https://www.hepsiburada.com");

                var responseAsText = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"2.Thread Gelen Data Length:{responseAsText.Length}");
            });

            return Task.CompletedTask;
        }
    }
}
