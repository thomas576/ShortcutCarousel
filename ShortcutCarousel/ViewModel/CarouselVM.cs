using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortcutCarousel.Model;
using System.Collections.ObjectModel;
using ShortcutCarousel.UI.ShortcutCarouselService;
using System.Windows.Input;
using Microsoft.Practices.Unity;

namespace ShortcutCarousel.UI
{
	public class CarouselVM : ViewModelBase
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region Private fields
		protected IConfigDefaultOSUser _ConfigDefaultOSUser;
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
				}
			}
		}

		private bool _StayOnTop;
		public bool StayOnTop
		{
			get { return _StayOnTop; }
			set
			{
				if (value != _StayOnTop)
				{
					_StayOnTop = value;
					OnPropertyChanged(@"StayOnTop");
				}
			}
		}

		private ObservableCollection<OSUserVM> _AvailableOSUsers;
		public ObservableCollection<OSUserVM> AvailableOSUsers
		{
			get { return _AvailableOSUsers; }
			set
			{
				if (value != _AvailableOSUsers)
				{
					_AvailableOSUsers = value;
					OnPropertyChanged(@"AvailableOSUsers");
				}
			}
		}
		#endregion

		#region Commands
		private RelayCommand _SwitchUserCommand;
		public ICommand SwitchUserCommand
		{
			get
			{
				if (_SwitchUserCommand == null)
				{
					_SwitchUserCommand = new RelayCommand(param => this.ExecuteSwitchUser(param), param => this.CanExecuteSwitchUser(param));
				}
				return _SwitchUserCommand;
			}
		}

		private RelayCommand _EditCurrentUserCommand;
		public ICommand EditCurrentUserCommand
		{
			get
			{
				if (_EditCurrentUserCommand == null)
				{
					_EditCurrentUserCommand = new RelayCommand(param => this.ExecuteEditCurrentUser(param), param => this.CanExecuteEditCurrentUser(param));
				}
				return _EditCurrentUserCommand;
			}
		}
		#endregion

		#region Contructors
		public CarouselVM(IConfigDefaultOSUser configDefaultOSUser)
		{
			this._ConfigDefaultOSUser = configDefaultOSUser;
			this.CarouselUserVM = new CarouselUserVM();

			IList<string> availableOSUsersList = new List<string>();
			UnityContainerHelper.Container.Resolve<IShortcutCarouselService>().Using(service => {
				foreach (string s in service.GetOSUserList())
				{
					availableOSUsersList.Add(s);
				}
			});

			this.AvailableOSUsers = new ObservableCollection<OSUserVM>();
			foreach (string item in availableOSUsersList)
			{
				this.AvailableOSUsers.Add(new OSUserVM() { OSUserName = item, IsCurrentOSUser = false });
			}

			if (this.AvailableOSUsers.Count == 0)
			{
				log.Error(@"CarouselVM() found no available osusers to load.");
			}
			else
			{
				bool found = false;
				foreach (OSUserVM osuserVM in this.AvailableOSUsers)
				{
					if (!found && osuserVM.OSUserName == this._ConfigDefaultOSUser.DefaultOSUSer)
					{
						this.SwitchToOSUser(osuserVM.OSUserName);
						found = true;
					}
				}
				if (!found)
				{
					log.Info(@"CarouselVM(): you have not correctly configured your default osuser and it has not been found.");
					this.SwitchToOSUser(this.AvailableOSUsers[0].OSUserName);
				}
			}

			this.StayOnTop = false;
		}
		#endregion

		#region Methods
		public void SwitchToOSUser(string osuser)
		{
			UnityContainerHelper.Container.Resolve<IShortcutCarouselService>().Using(service => {
				this.CarouselUserVM.User = service.GetUser(osuser);
			});

			foreach (OSUserVM osuserVM in this.AvailableOSUsers)
			{
				if (osuserVM.OSUserName == this.CarouselUserVM.User.OSUser)
				{
					osuserVM.IsCurrentOSUser = true;
				}
				else
				{
					osuserVM.IsCurrentOSUser = false;
				}
			}
		}

		private void ExecuteSwitchUser(object param)
		{
			this.SwitchToOSUser((string)param);
		}

		private bool CanExecuteSwitchUser(object param)
		{
			return true;
		}

		public void EditCurrentUser()
		{
			EditCurrentUserWindow editCurrentUserWindow = new EditCurrentUserWindow(this.CarouselUserVM);
			editCurrentUserWindow.Show();
		}

		private void ExecuteEditCurrentUser(object param)
		{
			this.EditCurrentUser();
		}

		private bool CanExecuteEditCurrentUser(object param)
		{
			return (this.CarouselUserVM.User != null);
		}
		#endregion
	}
}
