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
		public static void Using<T>(this T client, Action<T> work) where T : ICommunicationObject
		{
			try
			{
				work(client);
				client.Close();
			}
			catch (CommunicationException)
			{
				client.Abort();
			}
			catch (TimeoutException)
			{
				client.Abort();
			}
			catch (Exception)
			{
				client.Abort();
				throw;
			}
		}
	}
}
