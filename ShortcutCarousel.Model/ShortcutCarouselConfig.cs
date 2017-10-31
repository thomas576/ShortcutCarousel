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

		public static ShortcutCarouselConfig ReadConfig()
		{
			ShortcutCarouselConfig instance = new ShortcutCarouselConfig();
			try
			{
				string val = ConfigurationManager.ConnectionStrings["ConnectionStringPrimary"].ConnectionString;
				instance.ConnectionStringPrimary = val.ToString();
			}
			catch (Exception)
			{
				instance.ConnectionStringPrimary = @"User Id=OracleUser;Password=Password;Data Source=DatabaseName";
			}
			try
			{
				string val = ConfigurationManager.ConnectionStrings["ConnectionStringSecondary"].ConnectionString;
				instance.ConnectionStringSecondary = val.ToString();
			}
			catch (Exception)
			{
				instance.ConnectionStringSecondary = @"User Id=OracleUser;Password=Password;Data Source=DatabaseName";
			}
			try
			{
				string val = ConfigurationManager.ConnectionStrings["ConnectionStringTertiary"].ConnectionString;
				instance.ConnectionStringTertiary = val.ToString();
			}
			catch (Exception)
			{
				instance.ConnectionStringTertiary = @"User Id=OracleUser;Password=Password;Data Source=DatabaseName";
			}
			try
			{
				string val = ConfigurationManager.AppSettings["XMLDirectoryFullPath"];
				instance.XMLDirectoryFullPath = val.ToString();
			}
			catch (Exception)
			{
				instance.XMLDirectoryFullPath = @"C:\Users\Administrator\Desktop\Xml";
			}
			try
			{
				string val = ConfigurationManager.AppSettings["DefaultColorType"];
				instance.DefaultColorType = (ColorType)Enum.Parse(typeof(ColorType), val);
			}
			catch (Exception)
			{
				instance.DefaultColorType = ColorType.Grayscale;
			}
			try
			{
				string val = ConfigurationManager.AppSettings["DefaultLuminosity"];
				instance.DefaultLuminosity = Double.Parse(val);
			}
			catch (Exception)
			{
				instance.DefaultLuminosity = 0.8;
			}
			return instance;
		}

		private ShortcutCarouselConfig()
		{

		}

		public string ConnectionStringPrimary
		{
			get; set;
		}

		public string ConnectionStringSecondary
		{
			get; set;
		}

		public string ConnectionStringTertiary
		{
			get; set;
		}

		public string XMLDirectoryFullPath
		{
			get; set;
		}

		public ColorType DefaultColorType
		{
			get; set;
		}

		public double DefaultLuminosity
		{
			get; set;
		}
	}
}
