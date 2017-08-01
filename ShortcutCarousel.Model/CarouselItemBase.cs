using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace ShortcutCarousel.Model
{
	public abstract class CarouselItemBase : NotifyPropertyChangedBase
	{
		#region Private field
		private IColorConfiguration _ColorConfig;
		#endregion

		#region Properties
		private string _DisplayName;
		public string DisplayName
		{
			get
			{
				return _DisplayName;
			}
			set
			{
				if (this._DisplayName != value)
				{
					this._DisplayName = value;
					this.OnPropertyChanged(@"DisplayName");
				}
			}
		}

		[XmlIgnore]
		public Color ColorBackground
		{
			get
			{
				switch (this.ColorType)
				{
					case ColorType.Grayscale:
						return ColorHelper.CreateGrayscaleColorFromLuminosity(this.ColorLuminosity);
					case ColorType.Hue:
						return ColorHelper.CreateBackgroundColorFromHue(this.ColorHue);
					default:
						break;
				}
				return ColorHelper.CreateGrayscaleColorFromLuminosity(this._ColorConfig.DefaultLuminosity);
			}
		}

		private ColorType _ColorType;
		public ColorType ColorType
		{
			get
			{
				return _ColorType;
			}
			set
			{
				if (this._ColorType != value)
				{
					this._ColorType = value;
					this.OnPropertyChanged(@"ColorType");
					this.OnPropertyChanged(@"ColorBackground");
				}
			}
		}

		private double _ColorHue;
		public double ColorHue
		{
			get
			{
				return _ColorHue;
			}
			set
			{
				if (this._ColorHue != value)
				{
					this._ColorHue = value;
					this.OnPropertyChanged(@"ColorHue");
					this.OnPropertyChanged(@"ColorBackground");
				}
			}
		}

		private double _ColorLuminosity;
		public double ColorLuminosity
		{
			get
			{
				return _ColorLuminosity;
			}
			set
			{
				if (this._ColorLuminosity != value)
				{
					this._ColorLuminosity = value;
					this.OnPropertyChanged(@"ColorLuminosity");
					this.OnPropertyChanged(@"ColorBackground");
				}
			}
		}
		#endregion

		public CarouselItemBase()
		{

		}

		public CarouselItemBase(IColorConfiguration colorConfig)
		{
			this._ColorConfig = colorConfig;
			this._ColorType = this._ColorConfig.DefaultColorType;
			this._ColorLuminosity = this._ColorConfig.DefaultLuminosity;
		}
	}

	public enum ColorType : int
	{
		Grayscale = 0,
		Hue = 1
	}
}
