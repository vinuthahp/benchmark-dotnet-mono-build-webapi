using System;
using System.Configuration;
using System.Threading;
using Microsoft.Owin.Hosting;

namespace ApiPeople
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var service = MakeServiceName();
			var address = MakeAddress(args);
			RunUntilTermination(service, address);
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
