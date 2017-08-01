using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public class CarouselLogCollection : ObservableCollection<CarouselLogItem>
	{
		public CarouselLogCollection() : base()
		{

		}

		public CarouselLogCollection(IEnumerable<CarouselLogItem> enumerableList) : base(enumerableList)
		{

		}
	}
}
