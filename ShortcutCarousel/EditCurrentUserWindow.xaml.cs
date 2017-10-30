using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ShortcutCarousel.Model;

namespace ShortcutCarousel.UI
{
	/// <summary>
	/// Interaction logic for EditCurrentUserWindow.xaml
	/// </summary>
	public partial class EditCurrentUserWindow : Window
	{
		private EditCurrentUserVM _EditCurrentUserVM;
		public EditCurrentUserVM EditCurrentUserVM
		{
			get
			{
				return this._EditCurrentUserVM;
			}
			set
			{
				if (this._EditCurrentUserVM != value)
				{
					this._EditCurrentUserVM = value;
					this.DataContext = this._EditCurrentUserVM;
				}
			}
		}

		public EditCurrentUserWindow(CarouselUserVM carouselUserVM)
		{
			InitializeComponent();
			this.EditCurrentUserVM = new EditCurrentUserVM(carouselUserVM);
		}
	}
}
