using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    internal class ServiceHelper
    {
        public async Task MakeRequestToGoogle2()
        {
            var httpClient = new HttpClient();

            httpClient.GetAsync("http://www.google.com");



        }


        public async Task<string> MakeRequestToGoogle()
        {
            var httpClient = new HttpClient();

            var responseAsTask = httpClient.GetAsync("http://www.google.com");

            var kdv = 10 * 1.20m;

            var response = await responseAsTask;

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }
    }
}
