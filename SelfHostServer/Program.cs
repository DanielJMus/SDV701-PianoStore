using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Web.Http.SelfHost;

namespace SelfHostServer
{
	class Program
	{
		static void Main(string[] args)
		{
			Uri _baseAddress = new Uri("http://localhost:60064/");
			HttpSelfHostConfiguration config = new HttpSelfHostConfiguration(_baseAddress);
			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{action}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

			HttpSelfHostServer server = new HttpSelfHostServer(config);
			// Start Listening
			server.OpenAsync().Wait();
			Console.WriteLine("Piano Store Web-API Self-hosted on " + _baseAddress);
			Console.WriteLine("Hit ENTER to exit..");
			Console.ReadLine();
			server.CloseAsync().Wait();
		}
	}
}
