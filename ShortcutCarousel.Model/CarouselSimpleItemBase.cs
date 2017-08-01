using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShortcutCarousel.Model
{
	public abstract class CarouselSimpleItemBase : CarouselItemBase
	{
		#region Commands
		private RelayCommand _ClickCommand;
		public ICommand ClickCommand
		{
			get
			{
				if (_ClickCommand == null)
				{
					_ClickCommand = new RelayCommand(param => this.ClickAction(), param => this.CanExecuteClickAction());
				}
				return _ClickCommand;
			}
		}
		#endregion

		public CarouselSimpleItemBase() : base()
		{

		}

		public CarouselSimpleItemBase(IColorConfiguration colorConfig) : base(colorConfig)
		{

		}

		public abstract void ClickAction();

		protected abstract bool CanExecuteClickAction();
	}
}
