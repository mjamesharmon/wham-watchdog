using LastChristmas.Transform;

TransformerApplication app = ApplicationBuilder.Configure().
    WithAllTransforms().
    Build(args);

await app.RunAsync();

