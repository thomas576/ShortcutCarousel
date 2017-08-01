using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ShortcutCarousel.Service;

namespace ShortcutCarousel.Service.Host
{
	class Program
	{
		static void Main(string[] args)
		{
			using (ServiceHost shortcutServiceHost = new ServiceHost(typeof(ShortcutCarouselService)))
			{
				shortcutServiceHost.Open();
				Console.WriteLine(@"Service is now open at: {0}", DateTime.Now);
				Console.ReadKey();
			}
		}
	}
}
