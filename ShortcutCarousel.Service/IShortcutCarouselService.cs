using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ShortcutCarousel.Model;

namespace ShortcutCarousel.Service
{
	[ServiceContract]
	public interface IShortcutCarouselService
	{
		[OperationContract]
		CarouselUser GetUser(string osuser);

		[OperationContract]
		IList<string> GetOSUserList();
	}
}
