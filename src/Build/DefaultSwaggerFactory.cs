using PipServices3.Commons.Refer;
using PipServices3.Components.Build;
using PipServices3.Swagger.Services;

namespace PipServices3.Swagger.Build
{
    public class DefaultSwaggerFactory : Factory
    {
        public static Descriptor Descriptor = new Descriptor("pip-services", "factory", "swagger", "default", "1.0");
        
        public static Descriptor SwaggerServiceDescriptor = new Descriptor("pip-services", "swagger-service", "default", "default", "1.0");

        public DefaultSwaggerFactory()
        {
            RegisterAsType(SwaggerServiceDescriptor, typeof(SwaggerService));
        }
    }
}
