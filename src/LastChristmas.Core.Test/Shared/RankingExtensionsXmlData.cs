using System;
using System.Diagnostics.Metrics;

namespace LastChristmas.Core.Test.Shared
{
	public class RankingExtensionsXmlData
		: TheoryData<IEnumerable<Ranking>,string>
	{
		public RankingExtensionsXmlData()
        {
            Add(new List<Ranking>() {
                new Ranking("Denmark",0),
                new Ranking("Sweden",59),
                new Ranking("Austria",22),
                new Ranking("Germany",64) },
                File.ReadAllText("Shared/ranking_extensions_xml_data.xml"));

		}
	}
}

