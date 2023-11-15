using System;
using HtmlAgilityPack;

namespace LastChristmas.Core.Extensions
{
    /// <summary>
    /// Provides extension methods for parsing and manipulating HTML content.
    /// </summary>
    public static class HtmlParsingExtensions
	{
        /// <summary>
        /// Converts a string to an HTML-formatted string, wrapping it
        /// with an HTML tag if the input is empty or whitespace.
        /// </summary>
        /// <param name="value">The input string to be converted.</param>
        /// <returns>An HTML-formatted string.</returns>
        public static string AsHtmlString(this string value) =>
            string.IsNullOrWhiteSpace(value) ?
            "<html></html>" : value;

        /// <summary>
        /// Adds a new Ranking object to the list based on the
        /// provided HTML node and conversion function.
        /// </summary>
        /// <param name="list">The list of rankings to which the
        /// new ranking is added.</param>
        /// <param name="node">The HTML node containing data for the
        /// new ranking.</param>
        /// <param name="conversion">The conversion function to
        /// transform the HTML node into a Ranking object.</param>
        /// <returns>The updated list of rankings.</returns>
        public static List<Ranking> AddNode(this List<Ranking> list,
            HtmlNode node, Func<HtmlNode,Ranking> conversion)
        {
            list.Add(conversion(node));
            return list;
        }

        /// <summary>
        /// Selects and returns the inner text of an HTML node based on
        /// the provided CSS selector.
        /// </summary>
        /// <param name="node">The HTML node from which to select text.</param>
        /// <param name="selector">The CSS selector used to locate
        /// the desired node.</param>
        /// <returns>The inner text of the selected HTML node or
        /// "Unknown" if the node is not found.</returns>
        public static string SelectText(this HtmlNode node, string selector)
        {
            HtmlNode result = node.SelectSingleNode(selector);
            return (result == null) ? "Unknown" :
                result.InnerText;
        }

        /// <summary>
        /// Selects and returns the inner text of an HTML node as an
        /// integer based on the provided CSS selector.
        /// </summary>
        /// <param name="node">The HTML node from which to
        /// select text as an integer.</param>
        /// <param name="selector">The CSS selector used to
        /// locate the desired node.</param>
        /// <returns>The inner text of the selected HTML node parsed as an
        /// integer or 0 if parsing fails.</returns>
        public static int SelectTextAsInt(this HtmlNode node,
            string selector)
        {
            HtmlNode result = node.SelectSingleNode(selector);
            return (Int32.TryParse(result.InnerText, out int value)) ?
                value : 0;
        }
    }
}

