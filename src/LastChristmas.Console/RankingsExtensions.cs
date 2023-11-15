using System;
using System.Text;
using LastChristmas.Core;

namespace LastChristmas.Console
{
	public static class RankingsExtensions
	{
		private const string YesMessage =
			"Yes! Last Christmas has hit #1 in the following countries";

		private const string NoMessage =
			"No, Last Christmas is not at the top of any global charts";

        public static IEnumerable<string> CountriesAtNumberOne(
			this LastChristmasRankingResponse response) =>
			response.Rankings.
				Where(r => r.Rank == 1).
				Select(r => r.Country);


		public static string Display(this LastChristmasRankingResponse response)
		{
			return response.CountriesAtNumberOne().
				Count() > 0 ? response.Yes() : NoMessage;
		}

		public static string Yes(this LastChristmasRankingResponse response)
		{
			return response.CountriesAtNumberOne().
				Aggregate(new StringBuilder(YesMessage),
				(builder, country) => builder.AppendLine(country)).
				ToString();
        }	
	}
}

