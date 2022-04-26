using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HttpPerformance
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            TimeSpan TotalTimeUntilFinalTestCaseRequest;
            var startPoint = DateTime.UtcNow;
            // var endpoint = startPoint + TotalTimeUntilFinalTestCaseRequest;
            getAsset();

            Console.WriteLine("Hello World!");
        }
        public async void post()
        {
            var values = new Dictionary<string, string>
            {
                { "thing1", "hello" },
                { "thing2", "world" }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);
            var responseString = await response.Content.ReadAsStringAsync();
        }
        public static async void getAsset()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://r240340.deploy.radarlivex.ixstest.com/assets-management/v1/assets"),
                Method = HttpMethod.Get,
            };
           // client..Add("Content-Type", "form-data");
           client.DefaultRequestHeaders.Add("assetVersionId", "AC4B8774-A549-4BE0-899F-A5AADADC095D");

            // request.Headers.("Content-Type","form-data");
            // request.Headers.Add("assetVersionId", "AC4B8774-A549-4BE0-899F-A5AADADC095D");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

            //request.Content.Headers.ContentType = new MediaTypeHeaderValue("form-data");
            var task = await client.SendAsync(request);
            Console.WriteLine("status code = " + task.StatusCode);
        }
    }


}
