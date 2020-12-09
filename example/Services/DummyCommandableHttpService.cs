using PipServices3.Commons.Config;
using PipServices3.Commons.Refer;
using PipServices3.Rpc.Services;

namespace PipServices3.Swagger.Services
{
    public sealed class DummyCommandableHttpService : CommandableHttpService
    {
        public DummyCommandableHttpService() 
            : base("dummy")
        {
            _dependencyResolver.Put("controller", new Descriptor("pip-services3-dummies", "controller", "default", "*", "1.0"));
        }

		public override void Register()
		{
			if (!_swaggerAuto && _swaggerEnable)
			{
				RegisterOpenApiSpecFromResource("DummyRestServiceSwagger.yaml");
			}

			base.Register();
		}
	}
}
