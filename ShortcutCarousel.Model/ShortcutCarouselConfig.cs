using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ShortcutCarousel.Model
{
	public class ShortcutCarouselConfig : IDbConnectionConfig, IXmlDataMapperSettings, IColorConfiguration
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		private static ShortcutCarouselConfig instance = null;

		public static ShortcutCarouselConfig Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ShortcutCarouselConfig();
				}
				return instance;
			}
		}

		public ShortcutCarouselConfig()
		{

		}

		public string ConnectionStringPrimary
		{
			get
			{
				try
				{
					string val = ConfigurationManager.ConnectionStrings["ConnectionStringPrimary"].ConnectionString;
					return val.ToString();
				}
				catch (Exception)
				{
					return @"User Id=OracleUser;Password=Password;Data Source=DatabaseName";
				}
			}
		}

		public string ConnectionStringSecondary
		{
			get
			{
				try
				{
					string val = ConfigurationManager.ConnectionStrings["ConnectionStringSecondary"].ConnectionString;
					return val.ToString();
				}
				catch (Exception)
				{
					return @"User Id=OracleUser;Password=Password;Data Source=DatabaseName";
				}
			}
		}

		public string ConnectionStringTertiary
		{
			get
			{
				try
				{
					string val = ConfigurationManager.ConnectionStrings["ConnectionStringTertiary"].ConnectionString;
					return val.ToString();
				}
				catch (Exception)
				{
					return @"User Id=OracleUser;Password=Password;Data Source=DatabaseName";
				}
			}
		}

		public string XMLDirectoryFullPath
		{
			get
			{
				try
				{
					string val = ConfigurationManager.AppSettings["XMLDirectoryFullPath"];
					return val.ToString();
				}
				catch (Exception)
				{
					return @"C:\Users\Administrator\Desktop\Xml";
				}
			}
		}

		public ColorType DefaultColorType
		{
			get
			{
				try
				{
					string val = ConfigurationManager.AppSettings["DefaultColorType"];
					return (ColorType)Enum.Parse(typeof(ColorType), val);
				}
				catch (Exception)
				{
					return ColorType.Grayscale;
				}
			}
		}

		public double DefaultLuminosity
		{
			get
			{
				try
				{
					string val = ConfigurationManager.AppSettings["DefaultLuminosity"];
					return Double.Parse(val);
				}
				catch (Exception)
				{
					return 0.8;
				}
			}
		}
	}
}
