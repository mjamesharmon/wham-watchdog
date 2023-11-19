using System;
using System.Reflection;

namespace LastChristmas.Transform
{
	public static class Extensions
	{
        private static readonly string MarkdownTransform =
            "LastChristmas.Transform.md_transform.xsl";

        private static readonly string HtmlTransform =
            "LastChristmas.Transform.html_transform.xsl";

        public static string LoadMarkdownTransform(this Assembly assembly) {
            return assembly.LoadFromStream(MarkdownTransform);
        }

        public static string LoadHtmlTransform(this Assembly assembly) {
            return assembly.LoadFromStream(HtmlTransform);
        }

        private static string LoadFromStream(this Assembly assembly,
            string resourceName)
        {
            using (Stream? stream = assembly.
                GetManifestResourceStream(resourceName))
            using (StreamReader reader = stream.AsStreamReader())
            {
                return reader.ReadToEnd();
            }
        }

        private static StreamReader AsStreamReader(this Stream? stream) =>
            new StreamReader(stream ?? throw new InvalidOperationException());
	}
}

