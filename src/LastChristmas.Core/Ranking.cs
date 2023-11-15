using System;
using System.Globalization;

namespace LastChristmas.Core
{
	public record Ranking(string Country, int Rank = Ranking.NotRanked)
	{
		public const int NotRanked = 0;
	}
}

