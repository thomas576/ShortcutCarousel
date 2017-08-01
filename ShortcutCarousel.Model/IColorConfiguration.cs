using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public interface IColorConfiguration
	{
		ColorType DefaultColorType { get; }
		double DefaultLuminosity { get; }
	}
}
