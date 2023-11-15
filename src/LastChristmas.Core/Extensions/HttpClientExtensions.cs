using System;
namespace LastChristmas.Core.Extensions
{
	public static class HttpClientExtensions
	{
		public const string LastChristmasStatsUrl =
			"https://acharts.co/song/3018";

		public static Task<LastChristmasRankingResponse>
			GetLastChristmasRankingsAsync(this HttpClient client)
		{
			return client.GetStringAsync(LastChristmasStatsUrl).
				ContinueWith(t => t.Result.AsRankings());
		}

		private static LastChristmasRankingResponse AsRankings(this
			string response) => new LastChristmasRankingResponse(response);
	}
}

