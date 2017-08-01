using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ShortcutCarousel.Model;

namespace ShortcutCarousel.UI
{
	public class MainWindowVM : ViewModelBase
	{
		#region Private fields
		protected IConfigDefaultOSUser _ConfigDefaultOSUser;
		#endregion

		#region Commands
		private RelayCommand _ExitCommand;
		public ICommand ExitCommand
		{
			get
			{
				if (_ExitCommand == null)
				{
					_ExitCommand = new RelayCommand(param => Application.Current.Shutdown(), param => this.CanExecuteExit());
				}
				return _ExitCommand;
			}
		}
		#endregion

		private bool CanExecuteExit()
		{
			return true;
		}

		#region Properties
		private CarouselVM _CarouselVM;
		public CarouselVM CarouselVM
		{
			get { return _CarouselVM; }
			set
			{
				if (value != _CarouselVM)
				{
					_CarouselVM = value;
					OnPropertyChanged(@"CarouselVM");
				}
			}
		}
		#endregion

		public MainWindowVM(IConfigDefaultOSUser configDefaultOSUser)
		{
			this._ConfigDefaultOSUser = configDefaultOSUser;
			this.CarouselVM = new CarouselVM(this._ConfigDefaultOSUser);
		}

	}
}
