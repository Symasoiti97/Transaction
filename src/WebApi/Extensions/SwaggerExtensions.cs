using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Extensions;

internal static class SwaggerExtensions
{
    public static void SwaggerGenOptions(SwaggerGenOptions options)
    {
        options.SwaggerDoc("v1", new OpenApiInfo {Title = "Transaction API", Version = "v1"});

        options.CustomSchemaIds(x => x.FullName);

        options.UseAllOfToExtendReferenceSchemas();

        foreach (var fileName in Directory.GetFiles(AppContext.BaseDirectory, "*.xml"))
        {
            options.IncludeXmlComments(fileName, includeControllerXmlComments: true);
        }
    }
}