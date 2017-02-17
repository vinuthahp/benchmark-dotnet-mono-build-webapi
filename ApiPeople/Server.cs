namespace ApiPeople
{
	using System;
	using System.Configuration;
	using System.Data.Entity;
	using System.Threading;
	using Microsoft.Owin.Hosting;

	public class Server
	{
		private readonly string[] args;

		public Server(string[] args)
		{
			this.args = args;
		}

		public Server UpdateDatabase()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<EF6Context, ApiPeople.Migrations.Configuration>());
			return this;
		}

		public void LaunchAndWait()
		{
			RunUntilTermination(MakeServiceName(), MakeAddress(args));
		}

		private static string MakeServiceName()
		{
			var service = ConfigurationManager.AppSettings["ServicePort"] as string;
			if (service != null)
				return service;
			else
				return "web-api";
		}

		private static string MakeAddress(string[] args)
		{
			var port = 80;

			if (args.Length > 1 && (args[0] == "--port" || args[0] == "-p"))
				int.TryParse(args[1], out port);
			else
			{
				var portConfig = ConfigurationManager.AppSettings["ServicePort"];
				if (portConfig != null)
					int.TryParse(portConfig, out port);
			}

			return string.Format("http://*:{0}", port);
		}

		private static void RunUntilTermination(string service, string address)
		{
			using (var server = WebApp.Start<Startup>(url: address))
			{
				Console.WriteLine("[ASP.NET WebApi] {0} up at {1}", service, address);
				Console.WriteLine("Press CTRL + C to terminate...");
				Thread.Sleep(Timeout.Infinite);
			}
		}
	}
}
