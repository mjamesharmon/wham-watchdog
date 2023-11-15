using System;
using HtmlAgilityPack;

namespace LastChristmas.Core.Extensions
{
	public static class HtmlParsingExtensions
	{
        public static string AsHtmlString(this string value) =>
            string.IsNullOrWhiteSpace(value) ?
            "<html></html>" : value;

        public static List<Ranking> AddNode(this List<Ranking> list,
            HtmlNode node, Func<HtmlNode,Ranking> conversion)
        {
            list.Add(conversion(node));
            return list;
        }


        public static string SelectText(this HtmlNode node, string selector)
        {
            HtmlNode result = node.SelectSingleNode(selector);
            return (result == null) ? "Unknown" :
                result.InnerText;
        }

        public static int SelectTextAsInt(this HtmlNode node,
            string selector)
        {
            HtmlNode result = node.SelectSingleNode(selector);
            return (Int32.TryParse(result.InnerText, out int value)) ?
                value : 0;
        }
    }
}

