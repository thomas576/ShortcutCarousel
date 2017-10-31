using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShortcutCarousel.Model
{
	public interface IDbConnectionConfig
	{
		string ConnectionStringPrimary { get; }
		string ConnectionStringSecondary { get; }
		string ConnectionStringTertiary { get; }
	}
}
