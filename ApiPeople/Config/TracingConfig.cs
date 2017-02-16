using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace ApiPeople.Config
{
	public static class TracingConfig
	{
		public static HttpConfiguration ConfigureTracing(this HttpConfiguration config)
		{
			config.EnableSystemDiagnosticsTracing();

			var traceWriter = config.EnableSystemDiagnosticsTracing();
			traceWriter.IsVerbose = false;
			traceWriter.MinimumLevel = MakeTracingLevel();

			return config;
		}

		private static TraceLevel MakeTracingLevel()
		{
			var cofigLevel = ConfigurationManager.AppSettings["LogLevel"];
			var level = TraceLevel.Warn;
			Enum.TryParse(cofigLevel, out level);
			return level;
		}
	}
}
