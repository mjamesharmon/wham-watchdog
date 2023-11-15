using System;

namespace LastChristmas.Core.Test.Shared
{
	public class MockHttpMessageHandler : HttpMessageHandler
	{
        private MockRoutingMap _routing = new MockRoutingMap();

        public MockHttpMessageHandler() { }

        public MockHttpMessageHandler Map(string route,string response) {

            _routing.Add(route, (request) => new HttpResponseMessage
            {
                Content = new StringContent(response)
            });

            return this; 
        }

        public MockHttpMessageHandler Map(string route,
            Func<HttpRequestMessage,HttpResponseMessage> action)
        {
            _routing.Add(route, action);
            return this;
        }

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
           var action = _routing.GetValueOrDefault(request.AsUrl(),
                MockRoutingMap.NotFound);

            await Task.CompletedTask;
            return action(request);
        }
    }
}

