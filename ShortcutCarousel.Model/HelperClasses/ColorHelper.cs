using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ShortcutCarousel.Model
{
	public class ColorHelper
	{
		/// <summary>
		/// Creates a color well-suited to be used as a bcackground on the buttons.
		/// </summary>
		/// <param name="hue">
		/// A double between 0.0 and 1.0 where 1.0 corresponds to 360°.
		/// </param>
		/// <returns>
		/// A Wpf color
		/// </returns>
		public static Color CreateBackgroundColorFromHue(double hue)
		{
			return (Color)(new HSLColor(hue, 0.4, 0.75));
		}

		/// <summary>
		/// Creates a grayscale color with the given luminosity.
		/// </summary>
		/// <param name="luminosity">
		/// A double between 0.0 and 1.0.
		/// </param>
		/// <returns>
		/// A Wpf color
		/// </returns>
		public static Color CreateGrayscaleColorFromLuminosity(double luminosity)
		{
			return (Color)(new HSLColor(0.0, 0.0, luminosity));
		}
	}
}
