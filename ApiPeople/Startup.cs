using System.Web.Http;
using Owin;
using ApiPeople.Config;
using Microsoft.Owin.Diagnostics;

namespace ApiPeople
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration()
				.ConfigureDependencyInjection()
				.ConfigureRouting()
				.ConfigureTracing();

			app.UseWebApi(config);
			app.UseErrorPage(ErrorPageOptions.ShowAll);
		}
	}
}
