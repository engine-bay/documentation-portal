namespace EngineBay.DocumentationPortal
{
    using System;
    using System.Reflection;
    using EngineBay.Core;
    using Microsoft.Extensions.FileProviders;

    public class DocumentationPortalModule : BaseModule
    {
        public override WebApplication AddMiddleware(WebApplication app)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            if (currentAssembly is null)
            {
                throw new ArgumentException(nameof(currentAssembly));
            }

            var manifestEmbeddedProvider =
                new ManifestEmbeddedFileProvider(currentAssembly, "DocumentationPortal/site");

            app.UseDefaultFiles();
            app.UseStaticFiles(
                new StaticFileOptions
                {
                    FileProvider = manifestEmbeddedProvider,
                    RequestPath = "/documentation-portal",
                });
            return app;
        }
    }
}