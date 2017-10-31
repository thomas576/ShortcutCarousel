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

		public static ShortcutCarouselUIConfig ReadConfig()
		{
			ShortcutCarouselUIConfig instance = new ShortcutCarouselUIConfig();
			try
			{
				string val = ConfigurationManager.AppSettings["DefaultOSUSer"];
				instance.DefaultOSUSer = val.ToString();
			}
			catch (Exception)
			{
				instance.DefaultOSUSer = @"usera";
			}
			return instance;
		}

		private ShortcutCarouselUIConfig()
		{

		}

		public string DefaultOSUSer { get; set; }
	}
}
