using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace LastChristmas.Core.Extensions
{
	public static class RankingsExtensions
	{
		public static string Transform<T>(this IEnumerable<T> rankings,
            string xslt="") 
		{
            string xml = rankings.AsXml();
            Func<string,string,string> transformer =
                (string.IsNullOrWhiteSpace(xslt)) ?
                (xml, xslt) => xml : ApplyXslt;
            return transformer(rankings.AsXml(), xslt);
        }

        private static string Transform(this XmlReader reader, string xml) {

            var transformer = new XslCompiledTransform();
            transformer.Load(reader);
            StringBuilder writer = new StringBuilder();
            using (StringReader stringReader = new StringReader(xml))
            using (XmlReader xmlReader = XmlReader.Create(stringReader))
            using (XmlWriter xmlWriter = XmlWriter.Create(writer,new XmlWriterSettings {
                 Indent=true, OmitXmlDeclaration=true
            })) {
                transformer.Transform(xmlReader, xmlWriter);
            }

            return writer.ToString();
        }

        private static string ApplyXslt(string xml, string xslt) {

            using (StringReader stringReader = new StringReader(xslt))
            using (XmlReader xsltReader = XmlReader.Create(stringReader))
            {
              return xsltReader.Transform(xml);
            }     
        }

        private static string AsXml<T>(this IEnumerable<T> rankings) {
            XmlSerializer xml = new XmlSerializer(typeof(List<T>));
            using (StringWriter writer = new StringWriter())
            {
                xml.Serialize(writer, rankings.ToList());
                return writer.ToString();
            }
        }

        public static IEnumerable<Ranking> CountriesAtNumberOne(
           this LastChristmasRankingResponse response) =>
           response.Rankings.CountriesAtNumberOne();

        public static IEnumerable<Ranking> CountriesAtNumberOne(
            this IEnumerable<Ranking> rankings) =>
                rankings.Where(r => r.Rank == 1);

    }
}

