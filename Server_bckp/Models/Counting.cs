using System.Collections.Generic;
using System.Xml.Serialization;

namespace Server
{
    [XmlRoot(ElementName = "counting")]
	public class Counting
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "count")]
		public List<Count> Count { get; set; }
	}


}
