using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public class CarouselDatabaseCollection : ObservableCollection<CarouselDatabaseItem>
	{
		public CarouselDatabaseCollection() : base()
		{

		}

		public CarouselDatabaseCollection(IEnumerable<CarouselDatabaseItem> enumerableList) : base(enumerableList)
		{

		}
	}
}
