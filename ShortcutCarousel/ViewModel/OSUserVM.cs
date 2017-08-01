using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.UI
{
	public class OSUserVM : ViewModelBase
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region Private fields

		#endregion

		#region Properties
		private string _OSUserName;
		public string OSUserName
		{
			get { return _OSUserName; }
			set
			{
				if (value != _OSUserName)
				{
					_OSUserName = value;
					OnPropertyChanged(@"OSUserName");
				}
			}
		}

		private bool _IsCurrentOSUser;
		public bool IsCurrentOSUser
		{
			get { return _IsCurrentOSUser; }
			set
			{
				if (value != _IsCurrentOSUser)
				{
					_IsCurrentOSUser = value;
					OnPropertyChanged(@"IsCurrentOSUser");
				}
			}
		}
		#endregion

		#region Constructors
		public OSUserVM()
		{

		}
		#endregion

		#region Methods

		#endregion
	}
}
