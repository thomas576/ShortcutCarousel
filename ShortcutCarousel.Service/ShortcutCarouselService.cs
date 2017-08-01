using ShortcutCarousel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Media;

namespace ShortcutCarousel.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShortcutCarouselService" in both code and config file together.
	public class ShortcutCarouselService : IShortcutCarouselService
	{
		private bool _IsInitialized = false;
		private ShortcutCarouselConfig _ShortcutCarouselConfig = null;

		private void Initialize()
		{
			if (!this._IsInitialized)
			{
				this._ShortcutCarouselConfig = new ShortcutCarouselConfig();
			}
		}

		public CarouselUser GetUser(string osuser)
		{
			this.Initialize();
			CarouselUser user = new CarouselUserDataMapper(this._ShortcutCarouselConfig).Load(osuser);
			return user;
		}

		public IList<string> GetOSUserList()
		{
			this.Initialize();
			return new CarouselUserDataMapper(this._ShortcutCarouselConfig).DiscoverXmlUsersAvailable();
		}
	}
}
