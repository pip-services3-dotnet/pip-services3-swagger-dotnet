﻿using System;
using PipServices3.Commons.Config;
using PipServices3.Commons.Refer;
using PipServices3.Components.Log;
using PipServices3.Swagger.Services;

namespace PipServices3.Swagger
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new DummyController();
            var service = new DummyCommandableHttpService();
            var logger = new ConsoleLogger();
            var swagger = new SwaggerService();

            service.Configure(ConfigParams.FromTuples(
                "connection.protocol", "http",
                "connection.host", "localhost",
                "connection.port", 3000,
                "swagger.enable", "true"
            ));

            service.SetReferences(References.FromTuples(
                new Descriptor("pip-services3-dummies", "controller", "default", "default", "1.0"), controller,
                new Descriptor("pip-services3-dummies", "service", "rest", "default", "1.0"), service,
                new Descriptor("pip-services", "logger", "console", "default", "1.0"), logger,
                new Descriptor("pip-services", "swagger", "default", "default", "1.0"), swagger
            ));

            service.OpenAsync(null).Wait();

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}
