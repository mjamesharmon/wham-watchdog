using System;
namespace LastChristmas.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for interacting with an HttpClient to
    /// retrieve Last Christmas rankings.
    /// </summary>
    public static class HttpClientExtensions
	{
        /// <summary>
        /// The URL for retrieving Last Christmas statistics.
        /// </summary>
        public const string LastChristmasStatsUrl =
            //"https://acharts.co/song/3018";
            "https://music.apple.com/us/playlist/top-100-denmark/pl.d08496850bc840a4874e877177a69f9f";

        /// <summary>
        /// Asynchronously retrieves Last Christmas rankings using the
        /// provided HttpClient.
        /// </summary>
        /// <param name="client">The HttpClient used to make
        /// the request.</param>
        /// <returns>A task representing the asynchronous operation that,
        /// upon completion, returns the
        /// LastChristmasRankingResponse.</returns>
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

