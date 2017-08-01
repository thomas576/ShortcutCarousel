using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public class CarouselFolderItem : CarouselSimpleItemBase
	{
		#region Properties
		private string _FolderPath;
		public string FolderPath
		{
			get
			{
				return _FolderPath;
			}
			set
			{
				if (this._FolderPath != value)
				{
					this._FolderPath = value;
					this.OnPropertyChanged(@"FolderPath");
				}
			}
		}
		#endregion

		protected CarouselFolderItem() : base()
		{

		}

		public CarouselFolderItem(IColorConfiguration colorConfig) : base(colorConfig)
		{

		}

		public override void ClickAction()
		{
			System.Diagnostics.Process.Start(this.FolderPath);
		}

		protected override bool CanExecuteClickAction()
		{
			return true;
		}
	}
}
