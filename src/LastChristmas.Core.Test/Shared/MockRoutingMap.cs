using System;
using System.Net; 
namespace LastChristmas.Core.Test.Shared
{
	public class MockRoutingMap :
		Dictionary<string, Func<HttpRequestMessage, HttpResponseMessage>>
	{
		public MockRoutingMap() { }

	
		public static HttpResponseMessage NotFound(HttpRequestMessage request)
			=> new HttpResponseMessage(HttpStatusCode.NotFound);

	}
}

