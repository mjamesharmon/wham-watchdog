using System;
using System.Globalization;

namespace LastChristmas.Core
{
	public record Ranking {

		public Ranking() { }

		public Ranking(string country, int rank = Ranking.NotRanked) {
			this.Country = country;
			this.Rank = rank;
		}

        public const int NotRanked = 0;

        public string Country { get; set; } = string.Empty;

		public int Rank { get; set; } = Ranking.NotRanked;

	}
}

