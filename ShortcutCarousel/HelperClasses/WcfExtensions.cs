using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.UI
{
	public static class WcfExtensions
	{
		public static void Using<T>(this T client, Action<T> work) where T : ShortcutCarouselService.IShortcutCarouselService
		{
			ICommunicationObject service = client as ICommunicationObject;
			if (service != null)
			{
				try
				{
					work(client);
					service.Close();
				}
				catch (CommunicationException)
				{
					service.Abort();
				}
				catch (TimeoutException)
				{
					service.Abort();
				}
				catch (Exception)
				{
					service.Abort();
					throw;
				}
			}
			else
			{
				work(client);
			}
		}
	}
}
