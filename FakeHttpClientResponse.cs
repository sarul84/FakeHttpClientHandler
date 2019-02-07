//----------------------------------------------------------------------------------
// <copyright file="FakeHttpClientResponse.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>2/8/2019</date>
// <summary>Fake Http Client Response Test</summary>
//-----------------------------------------------------------------------------------

namespace Prakrishta.Data.Test
{
    using Newtonsoft.Json;
    using System.Net;
    using System.Net.Http;
    using System.Text;

    public class FakeHttpClientResponse
    {
        /// <summary>
        /// Test method that mimicks fake http request and response
        /// </summary>
        public void MockHttpClientTest()
        {
            var httpClientResponse = new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(this.YourMockData()), Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };

            var fakeHandler = new FakeHttpClientHandler(httpClientResponse);
            var httpClient = new HttpClient(fakeHandler)
            {
                BaseAddress = new System.Uri("https://test.io")
            };

            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
            };

            var response = httpClient.SendAsync(request);
        }

        /// <summary>
        /// Write your mock data here and use appropriate return type
        /// </summary>
        /// <returns></returns>
        private dynamic YourMockData()
        {
            return new object();
        }
    }
}
