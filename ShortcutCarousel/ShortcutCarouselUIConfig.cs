using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.UI
{
	public class ShortcutCarouselUIConfig : IConfigDefaultOSUser
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public string DefaultOSUSer
		{
			get
			{
				try
				{
					string val = ConfigurationManager.AppSettings["DefaultOSUSer"];
					return val.ToString();
				}
				catch (Exception)
				{
					return @"usera";
				}
			}
		}
	}
}
