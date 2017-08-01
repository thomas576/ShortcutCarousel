using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public interface ICarouselUserDataMapper
	{
		void Save(CarouselUser user);
		CarouselUser Load(string osuser);
	}
}
