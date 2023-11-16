using CommandLine;
using LastChristmas.Console;
using LastChristmas.Core;
using LastChristmas.Core.Extensions;

HttpClient http = new HttpClient();

await Parser.Default.ParseArguments<CommandLineOptions>(args)
       .MapResult(async (CommandLineOptions opts) =>
       {
           await http.GetLastChristmasRankingsAsync().
                ContinueWith(t => t.Result.CountriesAtNumberOne().
                    Transform(opts.Xslt)).
                ContinueWith(t =>
                    File.WriteAllTextAsync(opts.OutputFile, t.Result));
       },
       errs => Task.FromResult(-1)); // Invalid arguments

