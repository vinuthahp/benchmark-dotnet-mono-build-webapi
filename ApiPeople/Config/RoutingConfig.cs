using System.Web.Http;

namespace ApiPeople.Config
{
	public static class RoutingConfig
	{
		public static HttpConfiguration ConfigureRouting(this HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			return config;
		}
	}
}
