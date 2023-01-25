using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Server
{

    [XmlRoot(ElementName = "Root")]
	public class Root
	{

		[XmlElement(ElementName = "RemoteMessage")]
		public List<RemoteMessage> RemoteMessage { get; set; }
	}


}
