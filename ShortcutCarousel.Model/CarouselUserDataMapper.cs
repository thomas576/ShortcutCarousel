using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace ShortcutCarousel.Model
{
	public class CarouselUserDataMapper : AbstractXMLDataMapper, ICarouselUserDataMapper
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region Private fields
		
		#endregion

		#region Properties

		#endregion

		#region Constructors
		public CarouselUserDataMapper(IXmlDataMapperSettings xmlDataMapperSettings) : base(xmlDataMapperSettings)
		{
			
		}
		#endregion

		#region Methods
		public CarouselUser Load(string osuser)
		{
			try
			{
				using (var stream = File.OpenRead(this.CreateFileName(osuser)))
				{
					XmlSerializer serializer = XmlSerializer.FromTypes(new[] { typeof(CarouselUser) })[0];
					//var serializer = new XmlSerializer(typeof(CarouselUser));
					CarouselUser user = serializer.Deserialize(stream) as CarouselUser;
					return user;
				}
			}
			catch (Exception ex)
			{
				log.Error(string.Format(@"Load(string osuser = {0}) has thrown an exception: ", osuser), ex);
				throw ex;
			}
		}

		public void Save(CarouselUser user)
		{
			try
			{
				// first serialize the object to memory stream,
				// in case of exception, the original file is not corrupted
				using (MemoryStream ms = new MemoryStream())
				{
					var writer = new StreamWriter(ms);
					XmlSerializer serializer = XmlSerializer.FromTypes(new[] { typeof(CarouselUser) })[0];
					//var serializer = new System.Xml.Serialization.XmlSerializer(typeof(ShortcutCarousel.Model.CarouselUser));
					serializer.Serialize(writer, user);
					writer.Flush();

					// if the serialization succeed, rewrite the file.
					File.WriteAllBytes(this.CreateFileName(user.OSUser), ms.ToArray());
				}
			}
			catch (Exception ex)
			{
				log.Error(string.Format(@"Save(CarouselUser user = {0}) has thrown an exception: ", user), ex);
				throw ex;
			}
		}

		protected virtual string CreateFileName(string osuser)
		{
			// Filename contains the OSUser name for the user we want to serialize...
			DirectoryInfo saveDirectory = new DirectoryInfo(this._XmlDataMapperSettings.XMLDirectoryFullPath);
			return Path.Combine(saveDirectory.FullName, string.Format(@"carousel_user_{0}.xml", osuser));
		}

		public List<string> DiscoverXmlUsersAvailable()
		{
			List<string> xmlUsersList = new List<string>();
			try
			{
				DirectoryInfo saveDirectory = new DirectoryInfo(this._XmlDataMapperSettings.XMLDirectoryFullPath);
				FileInfo[] xmlFiles = saveDirectory.GetFiles("*.xml");
				Regex regexp = new Regex(@"^carousel_user_(\w*)\.xml$");
				foreach (FileInfo xmlFile in xmlFiles)
				{
					log.DebugFormat(@"DiscoverXmlUsersAvailable() has found the xml file with Name = '{0}'.", xmlFile.Name);
					Match match = regexp.Match(xmlFile.Name);
					if (match.Success)
					{
						string osuser = match.Groups[1].Value;
						log.DebugFormat(@"DiscoverXmlUsersAvailable() has found osuser = '{0}' in the xml file with Name = '{1}'.", osuser, xmlFile.Name);
						xmlUsersList.Add(osuser);
					}
				}
			}
			catch (Exception ex)
			{
				log.Error(@"DiscoverXmlUsersAvailable() has thrown an exception: ", ex);
			}
			return xmlUsersList;
		}
		#endregion
	}
}
