using System;
using System.Text.Json;
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
        private const string _listId = "schema:music-playlist";
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
          Playlist.AsRankings();
            

        private Playlist Playlist =>
            JsonSerializer.Deserialize<Playlist>(List) ??
                new Playlist();


        private string List =>
            _document.GetElementbyId(_listId).InnerText;

    }
}

