﻿using System.Web;
using System.Web.Http;

namespace ApiPeople
{
	public class Global : HttpApplication
	{
		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
		}
	}
}
