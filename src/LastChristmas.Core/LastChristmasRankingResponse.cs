using System;
namespace LastChristmas.Core
{
    /// <summary>
    /// Represents the response for the Last Christmas ranking request.
    /// </summary>
    public class LastChristmasRankingResponse 
	{
		private string _httpResponse = string.Empty;

		internal LastChristmasRankingResponse(string httpResponse) {
			_httpResponse = string.IsNullOrWhiteSpace(httpResponse) ?
				string.Empty : _httpResponse;
		}

        /// <summary>
        /// Gets the rankings associated with the Last Christmas response.
        /// </summary>
        /// <returns>
        /// An IEnumerable of Ranking objects that represent the chart positions 
        /// for the timeless hit "Last Christmas" by Wham! Warning: May induce 
        /// spontaneous singing and festive dance moves.
        /// </returns>
        public IEnumerable<Ranking> Rankings =>
			Enumerable.Empty<Ranking>();
	}
}

