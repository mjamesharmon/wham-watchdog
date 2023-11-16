using System;
namespace LastChristmas.Core.Test.Shared
{
	public class RankingExtensionsXsltData :
		TheoryData<IEnumerable<Ranking>,string,string>
	{
		public RankingExtensionsXsltData()
		{

            Add(new List<Ranking>() {
                new Ranking("Denmark",0),
                new Ranking("Sweden",59),
                new Ranking("Austria",22),
                new Ranking("Germany",64) },
             File.ReadAllText("Shared/ranking_extensions_xml_data.xsl"),
             File.ReadAllText("Shared/ranking_extensions_xml_data.html"));
        }
	}
}

