using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public class CarouselUser : NotifyPropertyChangedBase
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region Private fields

		#endregion

		#region Properties
		private CarouselDatabaseCollection _DatabaseCollection;
		public CarouselDatabaseCollection DatabaseCollection
		{
			get { return _DatabaseCollection; }
			set
			{
				if (value != _DatabaseCollection)
				{
					_DatabaseCollection = value;
					OnPropertyChanged(@"DatabaseCollection");
				}
			}
		}

		private CarouselScriptCollection _ScriptCollection;
		public CarouselScriptCollection ScriptCollection
		{
			get { return _ScriptCollection; }
			set
			{
				if (value != _ScriptCollection)
				{
					_ScriptCollection = value;
					OnPropertyChanged(@"ScriptCollection");
				}
			}
		}

		private CarouselLogCollection _LogCollection;
		public CarouselLogCollection LogCollection
		{
			get { return _LogCollection; }
			set
			{
				if (value != _LogCollection)
				{
					_LogCollection = value;
					OnPropertyChanged(@"LogCollection");
				}
			}
		}

		private CarouselFolderCollection _FolderCollection;
		public CarouselFolderCollection FolderCollection
		{
			get { return _FolderCollection; }
			set
			{
				if (value != _FolderCollection)
				{
					_FolderCollection = value;
					OnPropertyChanged(@"FolderCollection");
				}
			}
		}

		private string _OSUser;
		public string OSUser
		{
			get { return _OSUser; }
			set
			{
				if (value != _OSUser)
				{
					_OSUser = value;
					OnPropertyChanged(@"OSUser");
				}
			}
		}
		#endregion

		#region Constructors
		public CarouselUser()
		{
			
		}
		#endregion

		#region Methods

		#endregion
	}
}
