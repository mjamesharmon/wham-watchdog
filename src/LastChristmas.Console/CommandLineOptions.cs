using System;
using CommandLine;

namespace LastChristmas.Console
{
	public class CommandLineOptions
	{
		[Value(index: 0, Required = true, HelpText = "Path to output file")]
		public string OutputFile { get; set; } = string.Empty;

		[Option(shortName: 'x', longName: "xslt", HelpText = "Path to xslt",
			Required = false, Default = "")]
		public string Xslt { get; set; } = string.Empty;
	}
}

