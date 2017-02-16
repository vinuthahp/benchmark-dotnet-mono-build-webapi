using System.Web.Http;
using ApiPeople.Domain.Person;
using ApiPeople.Infra.EF6;
using LightInject;

namespace ApiPeople.Config
{
	public static class IoCConfig
	{
		public static HttpConfiguration ConfigureDependencyInjection(this HttpConfiguration config)
		{
			var container = new ServiceContainer();
			RegisterServices(container);
			RegisterValidators(container);
			RegisterRepositories(container);
			RegisterContexts(container);
			container.RegisterApiControllers();
			container.EnableWebApi(config);
			return config;
		}

		private static void RegisterServices(IServiceRegistry c)
		{
			c.Register<IPersonService, PersonService>();
		}

		private static void RegisterValidators(IServiceRegistry c)
		{
			c.Register<IPersonValidatorForCreate, PersonValidatorForCreate>();
		}

		private static void RegisterRepositories(IServiceRegistry c)
		{
			c.Register<IPersonRepository, EF6PersonRepository>();
		}

		private static void RegisterContexts(IServiceRegistry c)
		{
			c.Register<IDbContext, EF6Context>();
		}
	}
}
