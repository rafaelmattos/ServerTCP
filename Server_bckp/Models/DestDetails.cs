using System.Collections.Generic;
using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "destDetails")]
	public class DestDetails
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "count")]
		public List<Count> Count { get; set; }
	}


}
