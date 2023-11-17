using System;
using CommandLine;

namespace LastChristmas.Console
{
	public class CommandLineOptions
	{
		[Value(index: 0, Required = true, HelpText = "Path to output file")]
		public string OutputPath { get; set; } = string.Empty;

		[Option(shortName: 't', longName: "transform", HelpText = "Path to xslt",
			Required = false, Default = "")]
		public string Xslt { get; set; } = string.Empty;

		[Option(shortName: 'o', longName: "output",
			HelpText = "filename for output produced by the -t option",
			Default = "")]
		public string OutputFile { get; set; } = string.Empty;

		[Option(longName: "md", Required = false,
			HelpText = "inclide markdown transform")]
		public bool IncludeMarkdown { get; set; } = false;

		[Option(longName: "html", Required = false,
			HelpText = "Include html transform")]
		public bool IncludeHtml { get; set; } = false;

		[Option(longName: "xml", Required = false,
			HelpText = "include raw xml")]
		public bool IncludeXml { get; set; } = false;
	}
}

