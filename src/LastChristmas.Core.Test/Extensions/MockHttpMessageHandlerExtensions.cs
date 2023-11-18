using System;
using LastChristmas.Core.Test.Shared;
using LastChristmas.Core.Extensions;

namespace LastChristmas.Core.Test.Extensions
{
	public static class MockHttpMessageHandlerExtensions
	{
		public static MockHttpMessageHandler WithDefaults(
			this MockHttpMessageHandler handler, string? payload)
		{
			return handler.Map(HttpClientExtensions.LastChristmasStatsUrl,
				payload ?? string.Empty);
			
		}
	}
}

