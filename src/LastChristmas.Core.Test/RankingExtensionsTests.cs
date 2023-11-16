using System;
using LastChristmas.Core.Test.Shared;
using LastChristmas.Core.Extensions;

namespace LastChristmas.Core.Test

{
	public class RankingExtensionsTests
	{


		[Theory]
		[ClassData(typeof(RankingExtensionsCountsData))]
		public void NumberOneCountries_NormalData_Ok(
			IEnumerable<Ranking> rankings, int expectedCount) {


			var numberOnes = rankings.CountriesAtNumberOne();

			Assert.NotNull(numberOnes);
			Assert.Equal(expectedCount, numberOnes.Count());

		}


		[Theory]
		[ClassData(typeof(RankingExtensionsXmlData))]
		public void Transform_NoXslt_Ok(IEnumerable<Ranking> rankings,
			string expectedXml) {

			string xml = rankings.Transform();

			Assert.Equal(expectedXml, xml);
		}

        [Theory]
        [ClassData(typeof(RankingExtensionsXsltData))]
        public void Transform_WithXslt_Ok(IEnumerable<Ranking> rankings,
            string xslt, string expectedHtml)
        {

            string html = rankings.Transform(xslt);

            Assert.Equal(expectedHtml.Replace(" ",""), html.Replace(" ",""));
        }
    }
}

