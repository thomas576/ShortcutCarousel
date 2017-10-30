using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortcutCarousel.Model;

namespace ShortcutCarousel.UI
{
	public class EditCurrentUserVM : ViewModelBase
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region Private fields

		#endregion

		#region Properties
		private CarouselUserVM _CarouselUserVM;
		public CarouselUserVM CarouselUserVM
		{
			get { return _CarouselUserVM; }
			set
			{
				if (value != _CarouselUserVM)
				{
					_CarouselUserVM = value;
					OnPropertyChanged(@"CarouselUserVM");
					OnPropertyChanged(@"WindowTitle");
				}
			}
		}
		
		public string WindowTitle
		{
			get { return string.Format(@"Editing '{0}'.", this.CarouselUserVM.User.OSUser); }
		}
		#endregion

		#region Constructors
		public EditCurrentUserVM(CarouselUserVM carouselUserVM)
		{
			this.CarouselUserVM = carouselUserVM;
		}
		#endregion

		#region Methods

		#endregion
	}
}
