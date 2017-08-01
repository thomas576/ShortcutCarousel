using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public abstract class AbstractXMLDataMapper
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		#region Private fields
		protected IXmlDataMapperSettings _XmlDataMapperSettings;
		#endregion

		#region Properties

		#endregion

		#region Constructors
		public AbstractXMLDataMapper(IXmlDataMapperSettings xmlDataMapperSettings)
		{
			this._XmlDataMapperSettings = xmlDataMapperSettings;
		}
		#endregion

		#region Methods

		#endregion
	}
}
