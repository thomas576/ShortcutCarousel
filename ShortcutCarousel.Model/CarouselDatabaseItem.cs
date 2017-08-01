using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShortcutCarousel.Model
{
	public class CarouselDatabaseItem : CarouselItemBase
	{
		#region Properties
		private string _DBName;
		public string DBName
		{
			get
			{
				return _DBName;
			}
			set
			{
				if (this._DBName != value)
				{
					this._DBName = value;
					this.OnPropertyChanged(@"DBName");
				}
			}
		}

		private string _Username;
		public string Username
		{
			get
			{
				return _Username;
			}
			set
			{
				if (this._Username != value)
				{
					this._Username = value;
					this.OnPropertyChanged(@"Username");
				}
			}
		}

		private string _Password;
		public string Password
		{
			get
			{
				return _Password;
			}
			set
			{
				if (this._Password != value)
				{
					this._Password = value;
					this.OnPropertyChanged(@"Password");
				}
			}
		}
		#endregion

		#region Commands
		private RelayCommand _ClickCopyDBNameCommand;
		public ICommand ClickCopyDBNameCommand
		{
			get
			{
				if (_ClickCopyDBNameCommand == null)
				{
					_ClickCopyDBNameCommand = new RelayCommand(
						param => this.ClickAction(ButtonClickedAction.CopyDBName), 
						param => this.CanExecuteClickAction(ButtonClickedAction.CopyDBName)
					);
				}
				return _ClickCopyDBNameCommand;
			}
		}

		private RelayCommand _ClickCopyUsernameCommand;
		public ICommand ClickCopyUsernameCommand
		{
			get
			{
				if (_ClickCopyUsernameCommand == null)
				{
					_ClickCopyUsernameCommand = new RelayCommand(
						param => this.ClickAction(ButtonClickedAction.CopyUsername),
						param => this.CanExecuteClickAction(ButtonClickedAction.CopyUsername)
					);
				}
				return _ClickCopyUsernameCommand;
			}
		}

		private RelayCommand _ClickCopyPasswordCommand;
		public ICommand ClickCopyPasswordCommand
		{
			get
			{
				if (_ClickCopyPasswordCommand == null)
				{
					_ClickCopyPasswordCommand = new RelayCommand(
						param => this.ClickAction(ButtonClickedAction.CopyPassword),
						param => this.CanExecuteClickAction(ButtonClickedAction.CopyPassword)
					);
				}
				return _ClickCopyPasswordCommand;
			}
		}
		#endregion

		protected CarouselDatabaseItem() : base()
		{

		}

		public CarouselDatabaseItem(IColorConfiguration colorConfig) : base(colorConfig)
		{

		}

		public void ClickAction(ButtonClickedAction action)
		{
			switch (action)
			{
				case ButtonClickedAction.CopyDBName:
					Clipboard.SetText(this.DBName);
					break;
				case ButtonClickedAction.CopyUsername:
					Clipboard.SetText(this.Username);
					break;
				case ButtonClickedAction.CopyPassword:
					Clipboard.SetText(this.Password);
					break;
				default:
					break;
			}
		}

		protected bool CanExecuteClickAction(ButtonClickedAction action)
		{
			return true;
		}
	}

	public enum ButtonClickedAction : int
	{
		CopyDBName = 0,
		CopyUsername = 1,
		CopyPassword = 2
	}
}
