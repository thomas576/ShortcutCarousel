using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortcutCarousel.Model;
using ShortcutCarousel.UI.ShortcutCarouselService;

namespace ShortcutCarousel.UI
{
	public class CarouselUserVM : ViewModelBase
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region Private fields

		#endregion

		#region Properties
		private CarouselUser _User;
		public CarouselUser User
		{
			get { return _User; }
			set
			{
				if (value != _User)
				{
					_User = value;
					OnPropertyChanged(@"User");
				}
			}
		}
		#endregion

		#region Constructors
		public CarouselUserVM()
		{

		}
		#endregion

		#region Methods

		#endregion
	}
}
