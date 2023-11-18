using System;
using CommandLine;
using LastChristmas.Core;
using LastChristmas.Core.Extensions;

namespace LastChristmas.Transform
{
	public class ApplicationBuilder
	{
		private List<Action<TransformerApplication,CommandLineOptions>>
			_buildActions =new List<
				Action<TransformerApplication,CommandLineOptions>>();

		private ApplicationBuilder() { }

		internal ApplicationBuilder(
			IEnumerable<Action<TransformerApplication
				,CommandLineOptions>> buildActions) {
			_buildActions = new List<Action<TransformerApplication,
				CommandLineOptions>>(buildActions);
		}
			
		public static ApplicationBuilder Configure() {
			return new ApplicationBuilder();
		}

		public ApplicationBuilder AddXmlTransform() {

			_buildActions.Add(XmlActionOrExclude);
			return new ApplicationBuilder(_buildActions);
		}

        public ApplicationBuilder AddHtmlTransform() {
			_buildActions.Add(HtmlActionOrExclude);
			return new ApplicationBuilder(_buildActions);
		}

        public ApplicationBuilder AddMarkdownTransform() {
			_buildActions.Add(MarkdownOrExclude);
            return new ApplicationBuilder(_buildActions);
        }

		public ApplicationBuilder WithCustomXsltTransform() {
			_buildActions.Add(CustomActionOrExclude);
			return new ApplicationBuilder(_buildActions);
		}

        public ApplicationBuilder WithAllTransforms()
        {
            return this.AddXmlTransform().
                AddMarkdownTransform().
                AddHtmlTransform().
                WithCustomXsltTransform();
        }

		public TransformerApplication Build(string[] arguments) {
            return Parser.Default.
                ParseArguments<CommandLineOptions>(arguments).
                MapResult(options => _buildActions.Aggregate(
                    new TransformerApplication(),
                    (app, action) =>
                    {
                        action(app, options);
                        return app;
                    }),
                    errs => TransformerApplication.Misconfigured);
            }
           

        private void CustomActionOrExclude(TransformerApplication application,
			CommandLineOptions options)
        {
            if (ExcludeCustomAction(options))
                return;

            application.AddAction(async r =>
            {
                await File.WriteAllTextAsync(
                    OutputFile(options.OutputPath,
                        CustomOutputFileName(options)),
                    r.CountriesAtNumberOne().
                        Transform(
                        await File.ReadAllTextAsync(options.Xslt)));
            });
        }

   
        private void XmlActionOrExclude(TransformerApplication application,
			CommandLineOptions options)
        {
            if (ExcludeXml(options))
                return;

            application.AddAction(async r =>
            {   
                await File.WriteAllTextAsync(
                    OutputFile(options.OutputPath, "rankings.xml"),
                    r.CountriesAtNumberOne().
                        Transform());
             });
        }


        private void HtmlActionOrExclude(TransformerApplication application,
            CommandLineOptions options)
        {
            if (ExcludeHtml(options))
                return;

            application.AddAction(async r =>
            { 
                await File.WriteAllTextAsync(
                    OutputFile(options.OutputPath, "index.html"),
                    r.CountriesAtNumberOne().
                        Transform(await File.ReadAllTextAsync(
                            "html_transform.xsl")));          
            }); 
        }

       
        private void MarkdownOrExclude(TransformerApplication application,
            CommandLineOptions options)
        {
            if (ExcludeMarkdown(options))
                return;

            application.AddAction(async r =>
            {
                await File.WriteAllTextAsync(
                    OutputFile(options.OutputPath, "rankings.md"),
                    r.CountriesAtNumberOne().
                        Transform(await File.ReadAllTextAsync(
                            "md_transform.xsl")));
            });
        }

        private string OutputFile(params string[] paths)
        {
            return string.Join(Path.DirectorySeparatorChar, paths);
        }

        private bool ExcludeMarkdown(CommandLineOptions options) =>
            options.IncludeMarkdown == false;

        private bool ExcludeHtml(CommandLineOptions options) =>
            options.IncludeHtml == false;
       
        private bool ExcludeXml(CommandLineOptions options) =>
            options.ExcludeXml == true;

        private bool ExcludeCustomAction(CommandLineOptions options) =>
            string.IsNullOrWhiteSpace(options.Xslt);

        private string CustomOutputFileName(CommandLineOptions options) =>
            string.IsNullOrWhiteSpace(options.OutputFile) ?
            "rankings.out" : options.OutputFile;     
    }
}

