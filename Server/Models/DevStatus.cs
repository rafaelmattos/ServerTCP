using System.Collections.Generic;
using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "devStatus")]
	public class DevStatus
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "dev")]
		public List<Dev> Dev { get; set; }
	}


}
