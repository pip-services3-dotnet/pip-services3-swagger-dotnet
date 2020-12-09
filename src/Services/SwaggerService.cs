using Microsoft.AspNetCore.Builder;
using PipServices3.Rpc.Services;
using System.Collections.Generic;

namespace PipServices3.Swagger.Services
{
    public class SwaggerService : ISwaggerService
    {
        public void ConfigureApplication(IApplicationBuilder applicationBuilder, List<string> routes)
        {
            applicationBuilder
                .UseSwaggerUI(c =>
                {
                    routes.ForEach(a =>
                    {
                        c.SwaggerEndpoint(a, a);
                    });
                });
        }

        public void RegisterOpenApiSpec(string baseRoute, string content)
        {
        }
    }
}
