using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Schedulerer.Web.OpenApi
{
    public static class OpenApiExtensions
    {
        private const string AuthorizationHeader = "Authorization";
        private const string Title = "Schedulerer API";
        private const string Version = "v1";

        public static IServiceCollection AddOpenApi(this IServiceCollection services) => services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(Version, new OpenApiInfo {Title = Title, Version = Version});
            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standard Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                Type = SecuritySchemeType.ApiKey,
                Name = AuthorizationHeader,
                In = ParameterLocation.Header
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Name = AuthorizationHeader,
                        Type = SecuritySchemeType.ApiKey,
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });

        public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app) => app
            .UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{Version}/swagger.json", $"{Title} {Version}");
                c.DisplayOperationId();
                c.DisplayRequestDuration();
            });
    }
}