using System;
using PipServices3.Commons.Config;
using PipServices3.Commons.Refer;
using PipServices3.Components.Log;
using PipServices3.Rpc.Services;
using PipServices3.Swagger.Services;

namespace PipServices3.Swagger
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new DummyController();
            var service = new DummyCommandableHttpService();
            //var service = new DummyRestService();
            var logger = new ConsoleLogger();
            var endpoint = new HttpEndpoint();
            var swagger = new SwaggerService();

            var config = ConfigParams.FromTuples(
                "connection.protocol", "http",
                "connection.host", "localhost",
                "connection.port", 3000,
                "swagger.auto", "true",
                "swagger.enable", "true"
            );

            var references = References.FromTuples(
                new Descriptor("pip-services3-dummies", "controller", "default", "default", "1.0"), controller,
                new Descriptor("pip-services3-dummies", "service", "rest", "default", "1.0"), service,
                new Descriptor("pip-services", "logger", "console", "default", "1.0"), logger,
                new Descriptor("pip-services", "endpoint", "http", "default", "1.0"), endpoint,
                new Descriptor("pip-services", "swagger-service", "default", "default", "1.0"), swagger
            );

            endpoint.Configure(config);
            service.Configure(config);

            swagger.SetReferences(references);
            service.SetReferences(references);

            endpoint.OpenAsync(null).Wait();
            service.OpenAsync(null).Wait();

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}
