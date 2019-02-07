//----------------------------------------------------------------------------------
// <copyright file="FakeHttpClientHandler.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>2/8/2019</date>
// <summary>Fake Http Client Handler</summary>
//-----------------------------------------------------------------------------------

namespace Prakrishta.Data.Test
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Fake http client handler class
    /// </summary>
    public class FakeHttpClientHandler : DelegatingHandler
    {
        /// <summary>
        /// Holds mock http response message
        /// </summary>
        private readonly HttpResponseMessage responseMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeHttpClientHandler"/> class.
        /// </summary>
        /// <param name="httpResponseMessage">Fake response message</param>
        public FakeHttpClientHandler(HttpResponseMessage httpResponseMessage)
        {
            this.responseMessage = httpResponseMessage;
        }

        /// <inheritdoc />
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(responseMessage);
        }
    }
}
