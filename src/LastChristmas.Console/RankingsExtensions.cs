using System;
using System.Text;
using LastChristmas.Core;
using LastChristmas.Core.Extensions;

namespace LastChristmas.Console
{
	public static class RankingsExtensions
	{
		private const string YesMessage =
			"Yes! Last Christmas has hit #1 in the following countries";

		private const string NoMessage =
			"No, Last Christmas is not at the top of any global charts";

      
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

