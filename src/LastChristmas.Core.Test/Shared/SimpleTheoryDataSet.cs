using System;
using LastChristmas.Core.Extensions;
using System.Globalization;

namespace LastChristmas.Core.Test.Shared
{
	public class SimpleTheoryDataSet : TheoryData<string, IEnumerable<Ranking>>
	{
		public SimpleTheoryDataSet()
		{
			Add(File.ReadAllText("Shared/last_christmas_payload.html"),
				new List<Ranking>() {

					new Ranking("Denmark",0),
					new Ranking("Sweden",59),
					new Ranking("Austria",0),
					new Ranking("Germany",64),
					new Ranking("UK",37),
					new Ranking("Finland",0)
				});
		}


	}
}

