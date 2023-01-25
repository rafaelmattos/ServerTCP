using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [XmlRoot(ElementName = "content")]
	public class Content
	{
		public int Id { get; set; }

		[XmlElement(ElementName = "count")]
		public List<Count> Count { get; set; }
	}


}
