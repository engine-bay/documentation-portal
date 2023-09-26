namespace EngineBay.DocumentationPortal
{
    using System;
    using System.Reflection;
    using EngineBay.Core;
    using Microsoft.Extensions.FileProviders;

    public class DocumentationPortalModule : IModule
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        /// <inheritdoc/>
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            return endpoints;
        }

        public WebApplication AddMiddleware(WebApplication app)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            if (currentAssembly is null)
            {
                throw new ArgumentException(nameof(currentAssembly));
            }

            var manifestEmbeddedProvider = new ManifestEmbeddedFileProvider(currentAssembly, "DocumentationPortal/site");

            app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = manifestEmbeddedProvider,
                RequestPath = "/documentation-portal",
            });
            return app;
        }
    }
}