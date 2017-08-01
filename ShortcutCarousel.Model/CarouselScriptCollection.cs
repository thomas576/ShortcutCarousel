using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public class CarouselScriptCollection : ObservableCollection<CarouselScriptItem>
	{
		public CarouselScriptCollection() : base()
		{

		}

		public CarouselScriptCollection(IEnumerable<CarouselScriptItem> enumerableList) : base(enumerableList)
		{

		}
	}
}
