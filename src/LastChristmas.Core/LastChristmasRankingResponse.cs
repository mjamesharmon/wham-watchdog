using System;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using LastChristmas.Core.Extensions;

namespace LastChristmas.Core
{
    /// <summary>
    /// Represents the response for the Last Christmas ranking request.
    /// </summary>
    public class LastChristmasRankingResponse 
	{
        private const string _chartXpath =
            "/html/body/div/div/div/main/div[2]/table/tbody/tr";

        private const string _titlePath = "td[2]";
        private const string _valuePath = "td[7]";

        private HtmlDocument _document;

		internal LastChristmasRankingResponse(string response) {

            _document = new HtmlDocument();
            _document.LoadHtml(response.AsHtmlString());
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
            _document.DocumentNode.
                SelectNodes(_chartXpath).Aggregate(new List<Ranking>(),
                (rankings, node) => rankings.AddNode(node,
                    node => GetRankingFor(node)));


        private Ranking GetRankingFor(HtmlNode node) =>
            new Ranking(GetText(node), GetRank(node));


        private string GetText(HtmlNode node)
        {

            string title = node.SelectText(_titlePath);
            return title.Replace("Singles Top", "").
                Trim().
                Split(" ", StringSplitOptions.RemoveEmptyEntries).
                FirstOrDefault("Unknown");
        }


        private int GetRank(HtmlNode node) =>
            node.SelectTextAsInt(_valuePath);
    }
}

