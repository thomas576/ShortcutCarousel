using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public class CarouselFolderCollection : ObservableCollection<CarouselFolderItem>
	{
		public CarouselFolderCollection() : base()
		{

		}

		public CarouselFolderCollection(IEnumerable<CarouselFolderItem> enumerableList) : base(enumerableList)
		{

		}
	}
}
