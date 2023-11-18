using System;
namespace LastChristmas.Core.Test
{
	public static class HttpRequestMessageExtensions
	{
		public static string AsUrl(this HttpRequestMessage request) =>
			(request.RequestUri == null) ? string.Empty :
				request.RequestUri.ToString();
	}
}

